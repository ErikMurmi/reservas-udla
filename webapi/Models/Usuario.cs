using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Usuario : IdentityUser
{
    public string Nombre { get; set; } = null!;

    public string IdBanner { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
