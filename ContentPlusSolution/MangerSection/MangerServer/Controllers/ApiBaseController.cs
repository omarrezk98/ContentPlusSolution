using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MangerServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApiBaseController : ControllerBase
    {
        public string MangerId { get { return GetMangerId(); } }
        private string GetMangerId()
        {
            string? m = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(m)) return m;
            throw new Exception("Error In Read ManagerId From Token");
        }

    }
}
