using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly ReservasCanchasUdlaContext _context;

        public UsuariosController(ReservasCanchasUdlaContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        // GET: api/Customer/1
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var customer = _context.Usuarios.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }
    }
}
