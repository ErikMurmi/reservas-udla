using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class ReservasCanchasUdlaContext : DbContext
{
    public ReservasCanchasUdlaContext()
    {
    }

    public ReservasCanchasUdlaContext(DbContextOptions<ReservasCanchasUdlaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cancha> Canchas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=TITOJARAMILLO\\SQLEXPRESS;Database=ReservasCanchasUDLA;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cancha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cancha__3214EC274BE2A40B");

            entity.ToTable("Cancha");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Campus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Deporte)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoraFin).HasColumnName("Hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC274CE16FF3");

            entity.ToTable("Reserva");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CanchaId).HasColumnName("CanchaID");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasColumnName("Hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_inicio");
            entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");

            entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CanchaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_canchaFK");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.SolicitudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudFK");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC278C88324B");

            entity.ToTable("Solicitud");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CanchaId).HasColumnName("CanchaID");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Motivo).HasColumnType("text");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Cancha).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.CanchaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitud_canchaFK");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarioFK");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC270F25C7A7");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdBanner, "UQ__Usuario__C15351B36B811CC5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Carrera)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdBanner)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("ID_Banner");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
