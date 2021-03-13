using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api_barberia.Models;

#nullable disable

namespace api_barberia.Data
{
    public partial class barberia_bmContext : DbContext
    {
        public barberia_bmContext()
        {
        }

        public barberia_bmContext(DbContextOptions<barberia_bmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barbero> Barberos { get; set; }
        public virtual DbSet<BarberoServicio> BarberoServicios { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<SucursalBarbero> SucursalBarberos { get; set; }
        public virtual DbSet<SucursalServicio> SucursalServicios { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Barbero>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<BarberoServicio>(entity =>
            {
                entity.HasOne(d => d.Barbero)
                    .WithMany(p => p.BarberoServicios)
                    .HasForeignKey(d => d.BarberoId)
                    .HasConstraintName("FK__Barbero_S__barbe__44FF419A");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.BarberoServicios)
                    .HasForeignKey(d => d.ServicioId)
                    .HasConstraintName("FK__Barbero_S__servi__45F365D3");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Duracion).HasDefaultValueSql("((30))");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.Property(e => e.Direccion).IsUnicode(false);
            });

            modelBuilder.Entity<SucursalBarbero>(entity =>
            {
                entity.HasOne(d => d.Barbero)
                    .WithMany(p => p.SucursalBarberos)
                    .HasForeignKey(d => d.BarberoId)
                    .HasConstraintName("FK__Sucursal___barbe__3C69FB99");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.SucursalBarberos)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK__Sucursal___sucur__3B75D760");
            });

            modelBuilder.Entity<SucursalServicio>(entity =>
            {
                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.SucursalServicios)
                    .HasForeignKey(d => d.ServicioId)
                    .HasConstraintName("FK__Sucursal___servi__4222D4EF");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.SucursalServicios)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK__Sucursal___sucur__412EB0B6");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.Barbero)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.BarberoId)
                    .HasConstraintName("FK__Turno__barbero_i__4BAC3F29");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.ServicioId)
                    .HasConstraintName("FK__Turno__servicio___4AB81AF0");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.SucursalId)
                    .HasConstraintName("FK__Turno__sucursal___49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
