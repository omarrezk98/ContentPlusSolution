using AdminService.AdminSection;
using Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminServer.Controllers.AdminSection
{
    [Route("")]
    [ApiController]
    public class TokenController(IAuthenticateService authService, IAdminUserService adminService) : ControllerBase
    {
        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> RequestToken(TokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await authService.IsAuthenticated(request);

            if (model.IsAuthenticated)
            {
                return Ok(model.AccessToken);
            }
            return BadRequest("Login.LoginError");
        }

        [HttpPost]
        [Route("Token/Refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken.RefreshToken))
                return BadRequest();

            var refreshTokenFromDatabase = await adminService.GetRefreshToken(refreshToken.RefreshToken);
            if (refreshTokenFromDatabase == null || refreshTokenFromDatabase.Admin == null
                || refreshTokenFromDatabase.ExpiresUtc < DateTime.UtcNow.ToUniversalTime()
                || refreshTokenFromDatabase.Admin.IsDeleted)
                return BadRequest("Login.AutoLogout");

            var model = await authService.IsAuthenticated(refreshTokenFromDatabase.Admin);

            if (model.IsAuthenticated)
            {
                return Ok(model.AccessToken);
            }
            return BadRequest("Login.AutoLogout");
        }

        [HttpPost]
        [Route("Token/Logout")]
        public async Task<IActionResult> Logout(RefreshTokenRequest refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken.RefreshToken)) return BadRequest();
            await adminService.RemoveRefreshToken(refreshToken.RefreshToken);
            return Ok();
        }
    }
}
