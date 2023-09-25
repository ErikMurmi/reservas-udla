using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Authorize]
    public class AuthTestController : Controller
    {
        [HttpGet("Admin")]
        public string Admin()
        {
            return "Admin Allowed";
        }

        [HttpGet("User")]
        public string User()
        {
            return "Hi there!";
        }
    }
}
