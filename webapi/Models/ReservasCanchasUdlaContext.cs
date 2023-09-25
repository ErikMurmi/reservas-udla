using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class ReservasCanchasUdlaContext : IdentityDbContext
{
    public ReservasCanchasUdlaContext()
    {
    }

    public ReservasCanchasUdlaContext(DbContextOptions<ReservasCanchasUdlaContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Cancha> Canchas { get; set; }
    public virtual DbSet<Reserva> Reservas { get; set; }
    public virtual DbSet<Solicitud> Solicitudes { get; set; }
}
