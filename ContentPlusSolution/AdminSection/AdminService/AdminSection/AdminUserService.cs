using AdminUserService;
using Core.Security;
using AdminModel.AdminSection;
using Entity.AdminSection;
using AutoMapper;
using Entity;
using MongoDB.Driver;
using MongoDiagnosis;
using Core.Helper;
using Microsoft.EntityFrameworkCore;
using Core.Shared.Security;


namespace AdminService.AdminSection
{
    public interface IAdminUserService : IBaseService
    {
        Task<IsValidUserModel> IsValidUser(string username, string password);
        Task<int> SaveRefreshToken(AdminRefreshTokenViewModel refresh);
        Task<AdminRefreshToken?> GetRefreshToken(string token);
        Task<int> RemoveRefreshToken(string? token);
        Task<bool> ChangePassword(ChangePassword model, string userId);
    }
    public class AdminUserService(EntityContext db, IMapper mapper, IMongoDatabaseSettings mongoDBSettings, IMongoClient mongoClient) 
        : BaseService(db, mapper, mongoDBSettings, mongoClient)
        , IAdminUserService
    {
        public async Task<AdminRefreshToken?> GetRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var refreshToken = await db.AdminRefreshTokens.Include(x => x.Admin).SingleOrDefaultAsync(t => t.Id == token);
            if (refreshToken != null)
            {
                db.AdminRefreshTokens.Remove(refreshToken);
                await db.SaveChangesAsync();
            }
            return refreshToken;
        }

        public async Task<IsValidUserModel> IsValidUser(string username, string password)
        {
            var validUser = new IsValidUserModel();
            try
            {
                Admin? user = await db.Admins
                     .Where(s => s.UserName == username || s.Email == username)
                     .FirstOrDefaultAsync();
                if (!(user == null || user.IsDeleted == true || string.IsNullOrEmpty(user.PasswordHash)
                    || !IdentityHelper.VerifyHashedPassword(user.PasswordHash, password)))
                {
                    validUser.IsValidUser = true;
                    validUser.UserId = user.Id;
                    validUser.User = Mapper.Map<AdminViewModel>(user);
                    validUser.SiteId = user.SiteId;
                }
                return validUser;
            }
            catch (Exception ex)
            {
                await LogError(ex, this.GetType().Name + "/IsValidUser");
                return validUser;
            }
        }

        public async Task<int> RemoveRefreshToken(string? token)
        {
            if (string.IsNullOrWhiteSpace(token)) return 0;
            var refreshDbToken = await db.AdminRefreshTokens.SingleOrDefaultAsync(t => t.Id == token);
            if (refreshDbToken != null) db.AdminRefreshTokens.Remove(refreshDbToken);
            return await db.SaveChangesAsync();
        }

        public async Task<int> SaveRefreshToken(AdminRefreshTokenViewModel model)
        {
            var refresh = Mapper.Map<AdminRefreshToken>(model);
            await db.AdminRefreshTokens.AddAsync(refresh);
            return await db.SaveChangesAsync();
        }

        public async Task<bool> ChangePassword(ChangePassword model, string userId)
        {
            try
            {
                Admin? user = await db.Admins.Where(s => s.Id == userId).FirstOrDefaultAsync();
                if (user == null) return false;
                if (IdentityHelper.VerifyHashedPassword(user.PasswordHash!, model.OldPassword))
                {
                    user.PasswordHash = IdentityHelper.HashPassword(model.NewPassword);
                    var loginList = db.AdminRefreshTokens.Where(s => s.Id == userId).ToList();
                    db.AdminRefreshTokens.RemoveRange(loginList);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await LogError(ex, "Admin/ChangePassword", userId);
                return false;
            }
        }

    }
}
