using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApiBaseController : ControllerBase
    {
        public string AdminId { get { return GetAdminId(); } }
        private string GetAdminId()
        {
            string? m = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(m)) return m;
            throw new Exception("Error In Read AdminId From Token");
        }
    }
}
