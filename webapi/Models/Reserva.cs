using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public partial class Reserva
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Solicitud")]
    public int SolicitudId { get; set; }
    [ForeignKey("Cancha")]
    public int CanchaId { get; set; }
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan HoraInicio { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan HoraFin { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cancha Cancha { get; set; } = null!;

    public virtual Solicitud Solicitud { get; set; } = null!;
}
