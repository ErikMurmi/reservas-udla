using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Services;
using webapi.Views;

namespace webapi.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class UsuarioController : Controller
    {
        private readonly ReservasCanchasUdlaContext _context;
        private readonly IAuthService _authService;

        public UsuarioController(ReservasCanchasUdlaContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService; 
        }

        [HttpPost("Registro")]
        public async Task<bool> RegisterUser(RegistroUsuarioView usuario)
        {
            return await _authService.RegistrarUsuario(usuario);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUsuarioView usuario)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Alguno de los campos requeridos es incorrecto o faltante");
            }

            var login = await _authService.Login(usuario);
            if (login)
            {
                var token = _authService.generateTokenString(usuario);
                return Ok(new { Authorization = token });
            }

            return BadRequest("Contraseña o mail incorrectos");
        }
    }
}
