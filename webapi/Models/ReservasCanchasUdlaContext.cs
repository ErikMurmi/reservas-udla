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

    public virtual DbSet<Solicitud> Solicituds { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CADENA_CONEXION"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cancha>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Cancha");

            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.Campus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Deporte)
                .HasMaxLength(255)
                .IsUnicode(false);
            //.HasColumnName("Hora_fin")
            entity.Property(e => e.HoraFin).HasColumnType("time(7)");
            // .HasColumnName("Hora_inicio")
            entity.Property(e => e.HoraInicio).HasColumnType("time(7)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Reserva");

            entity.Property(e => e.Id);
            entity.Property(e => e.UsuarioId);
            entity.Property(e => e.SolicitudId);
            entity.Property(e => e.CanchaId);
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasColumnType("time(7)");
            entity.Property(e => e.HoraInicio).HasColumnType("time(7)");
            

            entity.HasOne(e => e.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId);

            entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CanchaId);

            entity.HasOne(d => d.Solicitud).WithOne(p => p.Reserva)
                .HasForeignKey<Reserva>(d => d.SolicitudId);
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Solicitud");

            entity.Property(e => e.Id);
            entity.Property(e => e.UsuarioId);
            entity.Property(e => e.CanchaId);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasColumnType("time(7)");
            entity.Property(e => e.HoraInicio).HasColumnType("time(7)");
            entity.Property(e => e.Motivo).HasColumnType("text");
            // No se como poner el constraint aquí, así que lo haré desde la api
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Cancha).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.CanchaId);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.UsuarioId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
