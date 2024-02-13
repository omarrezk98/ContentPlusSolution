using Core.Helper;
using Core.Security;
using Entity.MangerSection;
using MangerModel.MangerSection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MangerService.MangerSection
{
    public interface IAuthenticateService
    {
        Task<IsAuthenticatedModel> IsAuthenticated(TokenRequest request);
        Task<IsAuthenticatedModel> IsAuthenticated(Manger user);

    }
    public class AuthenticateService(IMangerService mangerService, IOptions<TokenManagement> tokenManagement) : IAuthenticateService
    {
        private readonly TokenManagement tokenManagement = tokenManagement.Value;

        public async Task<IsAuthenticatedModel> IsAuthenticated(TokenRequest request)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddDays(tokenManagement.AccessExpiration);
            var isAuthenticatedModel = new IsAuthenticatedModel();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return isAuthenticatedModel;

            var user = await mangerService.IsValidUser(request.Username, request.Password);
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
            int check = await mangerService.SaveRefreshToken(refresh);
            if (check < 0) return isAuthenticatedModel;

            isAuthenticatedModel.IsAuthenticated = true;
            isAuthenticatedModel.AccessToken = new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = accessTokenExpiration,
                Refresh = refresh,
                Profile = (MangerViewModel)user.User,
            };
            return isAuthenticatedModel;
        }

        public async Task<IsAuthenticatedModel> IsAuthenticated(Manger user)
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
            int check = await mangerService.SaveRefreshToken(refresh);
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

        private MangerRefreshTokenViewModel BuildRefreshToken(string userId)
        {
            return new MangerRefreshTokenViewModel
            {
                MangerId = userId,
                Token = IdentityHelper.HashPassword(Guid.NewGuid().ToString()),
                ExpiresUtc = DateTime.UtcNow.AddDays(tokenManagement.RefreshExpiration),
                IssuedUtc = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString()
            };
        }
    }

}

