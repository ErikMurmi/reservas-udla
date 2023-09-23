using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Cancha
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Campus { get; set; } = null!;

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public string Deporte { get; set; } = null!;

    public bool Habilitada { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
