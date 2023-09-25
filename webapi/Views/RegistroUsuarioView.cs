using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Views;

public partial class RegistroUsuarioView
{
    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = null!;

    [Required]
    [MaxLength(9)]
    public string IdBanner { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Carrera { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;
}
