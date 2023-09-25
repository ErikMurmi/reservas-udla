using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public partial class Cancha
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nombre { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Campus { get; set; } = null!;

    [Required]
    [DataType(DataType.Custom), CustomDataType("time(7)")]
    public TimeSpan HoraInicio { get; set; }

    [Required]
    [DataType(DataType.Custom), CustomDataType("time(7)")]
    public TimeSpan HoraFin { get; set; }

    [Required, MaxLength(255)]
    public string Deporte { get; set; } = null!;

    [Required]
    public bool Habilitada { get; set; }


    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
