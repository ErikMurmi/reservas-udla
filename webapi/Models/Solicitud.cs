using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public partial class Solicitud
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }
    [ForeignKey("Cancha")]
    public int CanchaId { get; set; }
    [DataType(DataType.Time)]
    public DateTime Fecha { get; set; }

    public string Motivo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Cancha Cancha { get; set; } = null!;

    public virtual Reserva Reserva { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
