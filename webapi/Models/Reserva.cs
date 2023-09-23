using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int SolicitudId { get; set; }

    public int CanchaId { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Cancha Cancha { get; set; } = null!;

    public virtual Solicitud Solicitud { get; set; } = null!;
}
