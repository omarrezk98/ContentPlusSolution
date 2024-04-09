using AutoMapper;
using Core.Helper;
using Core.Security;
using Core.Shared.Security;
using Entity;
using Entity.MangerSection;
using MangerModel.MangerSection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDiagnosis;

namespace MangerService.MangerSection
{
    public interface IMangerService : IBaseService
    {
        Task<IsValidUserModel> IsValidUser(string username, string password);
        Task<int> SaveRefreshToken(MangerRefreshTokenViewModel refresh);
        Task<MangerRefreshToken?> GetRefreshToken(string token);
        Task<int> RemoveRefreshToken(string? token);
        Task<bool> ChangePassword(ChangePassword model, string userId);
    }
    public class MangerService(EntityContext db, IMapper mapper, IMongoDatabaseSettings mongoDBSettings, IMongoClient mongoClient) 
        : BaseService(db, mapper, mongoDBSettings, mongoClient)
        , IMangerService
    {
        public async Task<IsValidUserModel> IsValidUser(string username, string password)
        {
            var validUser = new IsValidUserModel();
            try
            {
                Manger? user = await db.Mangers
                     .Where(s => s.UserName == username || s.Email == username)
                     .FirstOrDefaultAsync();
                if (!(user == null || user.IsDeleted == true || string.IsNullOrEmpty(user.PasswordHash)
                    || !IdentityHelper.VerifyHashedPassword(user.PasswordHash, password)))
                {
                    validUser.IsValidUser = true;
                    validUser.UserId = user.Id;
                    validUser.User = Mapper.Map<MangerViewModel>(user);
                }
                return validUser;
            }
            catch (Exception ex)
            {
                await LogError(ex, this.GetType().Name+"/IsValidUser");
                return validUser;
            }
        }

        public async Task<int> SaveRefreshToken(MangerRefreshTokenViewModel model)
        {
            var refresh = Mapper.Map<MangerRefreshToken>(model);
            await db.MangerRefreshTokens.AddAsync(refresh);
            return await db.SaveChangesAsync();
        }

        public async Task<MangerRefreshToken?> GetRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return null;
            var refreshToken = await db.MangerRefreshTokens.Include(x => x.Manger).SingleOrDefaultAsync(t => t.Id == token);
            if (refreshToken != null)
            {
                db.MangerRefreshTokens.Remove(refreshToken);
                await db.SaveChangesAsync();
            }
            return refreshToken;
        }

        public async Task<int> RemoveRefreshToken(string? token)
        {
            if (string.IsNullOrWhiteSpace(token)) return 0;
            var refreshDbToken = await db.MangerRefreshTokens.SingleOrDefaultAsync(t => t.Id == token);
            if (refreshDbToken != null) db.MangerRefreshTokens.Remove(refreshDbToken);
            return await db.SaveChangesAsync();
        }

        public async Task<bool> ChangePassword(ChangePassword model, string userId)
        {
            try
            {
                Manger? user = await db.Mangers.Where(s => s.Id == userId).FirstOrDefaultAsync();
                if (user == null) return false;
                if (IdentityHelper.VerifyHashedPassword(user.PasswordHash!, model.OldPassword))
                {
                    user.PasswordHash = IdentityHelper.HashPassword(model.NewPassword);
                    var loginList = db.MangerRefreshTokens.Where(s => s.Id == userId).ToList();
                    db.MangerRefreshTokens.RemoveRange(loginList);

                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                await LogError(ex, "Manger/ChangePassword", userId);
                return false;
            }
        }
    }
}
