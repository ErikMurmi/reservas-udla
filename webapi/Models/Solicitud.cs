using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Solicitud
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int CanchaId { get; set; }

    public DateTime Fecha { get; set; }

    public string Motivo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Cancha Cancha { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual Usuario Usuario { get; set; } = null!;
}
