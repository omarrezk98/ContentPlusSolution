using Core.Shared.Security;
using MangerService.MangerSection;
using Microsoft.AspNetCore.Mvc;

namespace MangerServer.Controllers.MangerSection
{ 
    public class AccountController(IMangerService mangerService) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
            =>await mangerService.ChangePassword(model, MangerId) ? BadRequest(Unauthorized()) : Ok();
    }
}
