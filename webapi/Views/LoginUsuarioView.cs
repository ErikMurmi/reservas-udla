using System.ComponentModel.DataAnnotations;

namespace webapi.Views;

public class LoginUsuarioView
{
    [Required]
    public string Password { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;
}
