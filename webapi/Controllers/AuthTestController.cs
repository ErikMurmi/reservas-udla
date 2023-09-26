using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthTestController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("Admin")]
        public string Admin()
        {
            return "Admin Allowed";
        }

        [Authorize(Roles = "User")]
        [HttpGet("Usuario")]
        public string Usuario()
        {
            return "Hi there!";
        }

        [HttpGet("Autorizado")]
        public string Autorizado()
        {
            return "Estás autorizado!";
        }
    }
}
