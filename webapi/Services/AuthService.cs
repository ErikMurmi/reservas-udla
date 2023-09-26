
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Views;

namespace webapi.Services;

public interface IAuthService
{
    Task<bool> RegistrarUsuario(RegistroUsuarioView usuario);
    Task<bool> Login(LoginUsuarioView usuario);
    Task<string> generateTokenString(LoginUsuarioView usuario);
}

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;

    //De quererse cambiar a obtener las variables de entorno desde el appconfig.json
    //Se debe inyectar IConfiguration
    public AuthService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    /* Falta añadir validaciones ??? 
     * y que lo que devuelva sea más coherente con el contexto ???
     * que se pone de username ??? */
    public async Task<bool> RegistrarUsuario(RegistroUsuarioView usuario)
    {
        var datosUsuario = new Usuario
        {
            UserName = usuario.Email,
            Nombre = usuario.Nombre,
            IdBanner = usuario.IdBanner,
            Carrera = usuario.Carrera,
            Email = usuario.Email
        };

        var result = await _userManager.CreateAsync(datosUsuario, usuario.Password);

        if(result.Succeeded)
        {
            await _userManager.AddToRoleAsync( datosUsuario ,"User");
        }

        return result.Succeeded;
    }

    public async Task<bool> Login(LoginUsuarioView usuario)
    {
        var datosLogin = await _userManager.FindByEmailAsync(usuario.Email);
        if (datosLogin == null)
        {
            return false;
        }

        return await _userManager.CheckPasswordAsync(datosLogin, usuario.Password);
    }

    public async Task<string> generateTokenString(LoginUsuarioView usuario)
    {
        // Obtener los roles del usuario para añadirlo al claim
        var user = await _userManager.FindByEmailAsync(usuario.Email);
        var roles = _userManager.GetRolesAsync(user);

        var sRoles = "";
        int i = 0;

        foreach (var role in roles.Result)
        {
            if (i != 0)
            {
                sRoles += ",";
            }
            sRoles += role;
            i++;
        }

        // Configuración de los claims para el token
        IEnumerable<System.Security.Claims.Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, sRoles)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("KEY")));

        var signInCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        SecurityToken securityToken = new JwtSecurityToken(
            claims:claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: Environment.GetEnvironmentVariable("ISSUER"),
            audience: Environment.GetEnvironmentVariable("AUDIENCE"),
            signingCredentials: signInCredential
            );
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }
}
