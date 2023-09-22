using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class Cancha
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Campus { get; set; } = null!;
    [DataType(DataType.Time)]
    public TimeSpan HoraInicio { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan HoraFin { get; set; }

    public string Deporte { get; set; } = null!;

    public bool Habilitada { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; set; }
}
