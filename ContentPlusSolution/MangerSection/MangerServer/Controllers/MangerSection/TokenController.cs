﻿using Core.Security;
using MangerService.MangerSection;
using Microsoft.AspNetCore.Mvc;

namespace MangerServer.Controllers.MangerSection
{
    [Route("")]
    [ApiController]
    public class TokenController(IAuthenticateService authService, IMangerService mangerService) : ControllerBase
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

            var refreshTokenFromDatabase = await mangerService.GetRefreshToken(refreshToken.RefreshToken);
            if (refreshTokenFromDatabase == null || refreshTokenFromDatabase.Manger == null
                || refreshTokenFromDatabase.ExpiresUtc < DateTime.UtcNow.ToUniversalTime()
                || refreshTokenFromDatabase.Manger.IsDeleted)
                return BadRequest("Login.AutoLogout");

            var model = await authService.IsAuthenticated(refreshTokenFromDatabase.Manger);

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
            await mangerService.RemoveRefreshToken(refreshToken.RefreshToken);
            return Ok();
        }
    }
}
