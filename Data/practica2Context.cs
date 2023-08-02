using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using ProyectoBaseDD.Models;

namespace ProyectoBaseDD.Data
{
    public partial class practica2Context : DbContext
    {
        

        public practica2Context(DbContextOptions<practica2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;
        public virtual DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<IngSistema> IngSistemas { get; set; } = null!;
        public virtual DbSet<Kardex> Kardices { get; set; } = null!;
        public virtual DbSet<NoSueldoP> NoSueldoPs { get; set; } = null!;
        public virtual DbSet<Prerequisito> Prerequisitos { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=practica2;User Id=postgres;Password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.CveAsig)
                    .HasName("pk_asig");

                entity.ToTable("asignatura");

                entity.HasIndex(e => e.Nombre, "asignatura_Nombre_key")
                    .IsUnique();

                entity.Property(e => e.CveAsig)
                    .HasMaxLength(13)
                    .HasColumnName("cve_asig");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.CveCarrera)
                    .HasMaxLength(13)
                    .HasColumnName("cve_carrera");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.CveCarreraNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.CveCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrera");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("bitacora_pkey");

                entity.ToTable("bitacora");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.ObjInfo)
                    .HasMaxLength(50)
                    .HasColumnName("obj_info");

                entity.Property(e => e.Operacion)
                    .HasMaxLength(50)
                    .HasColumnName("operacion");

                entity.Property(e => e.ValorAnterior)
                    .HasMaxLength(100)
                    .HasColumnName("valor_anterior");

                entity.Property(e => e.ValorNuevo)
                    .HasMaxLength(100)
                    .HasColumnName("valor_nuevo");

                entity.Property(e => e.Valores)
                    .HasMaxLength(100)
                    .HasColumnName("valores");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CveCarrera)
                    .HasName("carrera_pkey");

                entity.ToTable("carrera");

                entity.HasIndex(e => e.Nombre, "uni_car")
                    .IsUnique();

                entity.Property(e => e.CveCarrera)
                    .HasMaxLength(13)
                    .HasColumnName("cve_carrera");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Ncontrol)
                    .HasName("estudiantes_pkey");

                entity.ToTable("estudiantes");

                entity.Property(e => e.Ncontrol)
                    .HasMaxLength(8)
                    .HasColumnName("ncontrol");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .HasColumnName("apellido");

                entity.Property(e => e.CveCarrera)
                    .HasMaxLength(13)
                    .HasColumnName("cve_carrera");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .HasColumnName("nombre");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.HasOne(d => d.CveCarreraNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CveCarrera)
                    .HasConstraintName("fk_carrera");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.CveAsig)
                    .HasName("horario_pkey");

                entity.ToTable("horario");

                entity.Property(e => e.CveAsig)
                    .HasMaxLength(13)
                    .HasColumnName("cve_asig");

                entity.Property(e => e.Aula)
                    .HasMaxLength(5)
                    .HasColumnName("aula");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(2)
                    .HasColumnName("grupo");

                entity.Property(e => e.Horario1)
                    .HasMaxLength(7)
                    .HasColumnName("horario");

                entity.Property(e => e.IdProfesor)
                    .HasMaxLength(13)
                    .HasColumnName("id_profesor");

                entity.HasOne(d => d.CveAsigNavigation)
                    .WithOne(p => p.Horario)
                    .HasForeignKey<Horario>(d => d.CveAsig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("horario_cve_asig_fkey");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("horario_id_profesor_fkey");
            });

            modelBuilder.Entity<IngSistema>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ing_sistemas");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .HasColumnName("apellido");

                entity.Property(e => e.CveCarrera)
                    .HasMaxLength(13)
                    .HasColumnName("cve_carrera");

                entity.Property(e => e.Ncontrol)
                    .HasMaxLength(8)
                    .HasColumnName("ncontrol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .HasColumnName("nombre");

                entity.Property(e => e.Semestre).HasColumnName("semestre");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.HasKey(e => e.IdKardex)
                    .HasName("kardex_pkey");

                entity.ToTable("kardex");

                entity.Property(e => e.IdKardex)
                    .ValueGeneratedNever()
                    .HasColumnName("id_kardex");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.CveAsig)
                    .HasMaxLength(13)
                    .HasColumnName("cve_asig");

                entity.Property(e => e.Ncontrol)
                    .HasMaxLength(8)
                    .HasColumnName("ncontrol");

                entity.Property(e => e.TipoEval)
                    .HasMaxLength(4)
                    .HasColumnName("tipo_eval");

                entity.HasOne(d => d.CveAsigNavigation)
                    .WithMany(p => p.Kardices)
                    .HasForeignKey(d => d.CveAsig)
                    .HasConstraintName("kardex_cve_asig_fkey");

                entity.HasOne(d => d.NcontrolNavigation)
                    .WithMany(p => p.Kardices)
                    .HasForeignKey(d => d.Ncontrol)
                    .HasConstraintName("kardex_ncontrol_fkey");
            });

            modelBuilder.Entity<NoSueldoP>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("no_sueldo_p");

                entity.Property(e => e.Depto)
                    .HasMaxLength(25)
                    .HasColumnName("depto");

                entity.Property(e => e.GradAcadem)
                    .HasMaxLength(25)
                    .HasColumnName("grad_academ");

                entity.Property(e => e.IdProfesores)
                    .HasMaxLength(13)
                    .HasColumnName("id_profesores");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Prerequisito>(entity =>
            {
                entity.HasKey(e => e.IdPrerequisitos)
                    .HasName("pk_prerequisitos");

                entity.ToTable("prerequisitos");

                entity.Property(e => e.IdPrerequisitos)
                    .ValueGeneratedNever()
                    .HasColumnName("id_prerequisitos");

                entity.Property(e => e.CveAsig)
                    .HasMaxLength(13)
                    .HasColumnName("cve_asig");

                entity.Property(e => e.IdKardex).HasColumnName("id_kardex");

                entity.HasOne(d => d.CveAsigNavigation)
                    .WithMany(p => p.Prerequisitos)
                    .HasForeignKey(d => d.CveAsig)
                    .HasConstraintName("prerequisitos_cve_asig_fkey");

                entity.HasOne(d => d.IdKardexNavigation)
                    .WithMany(p => p.Prerequisitos)
                    .HasForeignKey(d => d.IdKardex)
                    .HasConstraintName("prerequisitos_id_kardex_fkey");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.IdProfesores)
                    .HasName("Profesores_pkey");

                entity.ToTable("profesores");

                entity.Property(e => e.IdProfesores)
                    .HasMaxLength(13)
                    .HasColumnName("id_profesores");

                entity.Property(e => e.Depto)
                    .HasMaxLength(25)
                    .HasColumnName("depto");

                entity.Property(e => e.GradAcadem)
                    .HasMaxLength(25)
                    .HasColumnName("grad_academ");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sueldo)
                    .HasColumnType("money")
                    .HasColumnName("sueldo");

                entity.HasOne(d => d.DeptoNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.Depto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profesores_depto_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
