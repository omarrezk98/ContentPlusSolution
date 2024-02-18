using AdminModel.AdminSection;
using Core.Helper;
using Core.Security;
using Entity.AdminSection;
using Entity.MangerSection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AdminService.AdminSection
{
    public interface IAuthenticateService
    {
        Task<IsAuthenticatedModel> IsAuthenticated(TokenRequest request);
        Task<IsAuthenticatedModel> IsAuthenticated(Admin user);

    }
    public class AuthenticateService(IAdminUserService adminService, IOptions<TokenManagement> tokenManagement) : IAuthenticateService
    {
        private readonly TokenManagement tokenManagement = tokenManagement.Value;

        public async Task<IsAuthenticatedModel> IsAuthenticated(TokenRequest request)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddDays(tokenManagement.AccessExpiration);
            var isAuthenticatedModel = new IsAuthenticatedModel();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return isAuthenticatedModel;

            var user = await adminService.IsValidUser(request.Username, request.Password);
            if (!user.IsValidUser || string.IsNullOrEmpty(user.UserId)) return isAuthenticatedModel;
            isAuthenticatedModel.IsValidUserModel = user;

            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
            };
            if (tokenManagement.Secret == null) return isAuthenticatedModel;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenManagement.Issuer,
                tokenManagement.Audience,
                claim,
                expires: DateTime.UtcNow.AddDays(tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            var refresh = BuildRefreshToken(user.UserId);
            int check = await adminService.SaveRefreshToken(refresh);
            if (check < 0) return isAuthenticatedModel;

            isAuthenticatedModel.IsAuthenticated = true;
            isAuthenticatedModel.AccessToken = new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = accessTokenExpiration,
                Refresh = refresh,
                Profile = (AdminViewModel)user.User,
            };
            return isAuthenticatedModel;
        }

        private AdminRefreshTokenViewModel BuildRefreshToken(string userId)
        {
            return new AdminRefreshTokenViewModel
            {
                AdminId = userId,
                Token = IdentityHelper.HashPassword(Guid.NewGuid().ToString()),
                ExpiresUtc = DateTime.UtcNow.AddDays(tokenManagement.RefreshExpiration),
                IssuedUtc = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString()
            };
        }
        public async Task<IsAuthenticatedModel> IsAuthenticated(Admin user)
        {
            var isAuthenticatedModel = new IsAuthenticatedModel();

            var accessTokenExpiration = DateTime.UtcNow.AddDays(tokenManagement.AccessExpiration);


            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            if (tokenManagement.Secret == null) return isAuthenticatedModel;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                tokenManagement.Issuer,
                tokenManagement.Audience,
                claim,
                expires: DateTime.UtcNow.AddDays(tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );

            var refresh = BuildRefreshToken(user.Id);
            int check = await adminService.SaveRefreshToken(refresh);
            if (check < 0) return isAuthenticatedModel;

            isAuthenticatedModel.IsAuthenticated = true;
            isAuthenticatedModel.AccessToken = new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = accessTokenExpiration,
                Refresh = refresh,
            };
            return isAuthenticatedModel;
        }
    }
}
