using AdminService.AdminSection;
using Core.Shared.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdminServer.Controllers.AdminSection
{
    public class AccountController(IAdminUserService adminService) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
            => await adminService.ChangePassword(model, AdminId) ? BadRequest(Unauthorized()) : Ok();
    }
}
