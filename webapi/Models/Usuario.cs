using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class Usuario : IdentityUser
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
}
