using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public partial class Reserva
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string UsuarioId { get; set; }

    [Required]
    public int SolicitudId { get; set; }

    [Required]
    public int CanchaId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    [Required]
    [DataType(DataType.Custom), CustomDataType("time(7)")]
    public TimeSpan HoraInicio { get; set; }

    [Required]
    [DataType(DataType.Custom), CustomDataType("time(7)")]
    public TimeSpan HoraFin { get; set; }

    [Required]
    [EnumDataType(typeof(EstadoSolicitud))]
    public string Estado { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    public virtual Usuario Usuario { get; set; } = null!;

    [ForeignKey("CanchaId")]
    public virtual Cancha Cancha { get; set; } = null!;

    [ForeignKey("SolicitudId")]
    public virtual Solicitud Solicitud { get; set; } = null!;
}
