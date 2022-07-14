
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Models;
using Microsoft.EntityFrameworkCore;

namespace HospiEnCasa.App.Dominio.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<FamiliarDesignado> familiaresDesignados { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Enfermera> enfermeras { get; set; }
        public DbSet<Historia> historias { get; set; }
        public DbSet<SignoVital> signosVitales { get; set; }
        public DbSet<SugerenciaCuidado> sugerenciasCuidados { get; set; }



        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Paciente>(patient =>
            {
                patient.ToTable("Pacientes");
                patient.HasKey(p => p.Id);
                patient.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                patient.Property(p => p.Apellidos).IsRequired().HasMaxLength(150);
                patient.Property(p => p.Direccion).IsRequired().HasMaxLength(150);
                patient.HasOne(p => p.Enfermera).WithMany(p => p.pacientes).HasForeignKey(p => p.EnfermeraId);
                patient.Property(p => p.Genero).IsRequired().HasDefaultValue(Genero.undefined);
                patient.HasOne(p => p.FamiliarDesignado).WithOne(p => p.paciente).HasForeignKey<Paciente>(p => p.FamiliarDesignadoId);
                patient.Property(p => p.FechaNacimiento).IsRequired().HasDefaultValue(DateTime.Now);
                patient.Property(p => p.Latitud).IsRequired(false);
                patient.Property(p => p.Longitud).IsRequired(false);
                patient.Property(p => p.NumeroTelefono).IsRequired(true);
                patient.Property(p => p.Ciudad);
                patient.HasOne(p => p.Historia).WithOne(p => p.paciente).HasForeignKey<Paciente>(p => p.HistoriaId);
                patient.HasOne(p => p.Medico).WithMany(p => p.paciente).HasForeignKey(p => p.MedicoId);


            });


            modelBuilder.Entity<Enfermera>(enfermeras =>
            {
                enfermeras.ToTable("Enfermeras");
                enfermeras.HasKey(p => p.Id);
                enfermeras.Property(p => p.HorasLaborales).IsRequired();
                enfermeras.Property(p => p.Apellidos).IsRequired(true);
                enfermeras.Property(p => p.Genero).IsRequired().HasDefaultValue(Genero.undefined);
                enfermeras.Property(p => p.TarjetaProfesional).IsRequired(true).HasMaxLength(10);
                enfermeras.Property(p => p.Nombre).IsRequired(true).HasMaxLength(100);
                enfermeras.Property(p => p.NumeroTelefono).IsRequired(true).HasMaxLength(10);
                enfermeras.Ignore(P => P.pacientes);
            });

            modelBuilder.Entity<FamiliarDesignado>(familiares =>
            {
                familiares.ToTable("Familiares");
                familiares.HasKey(p => p.Id);
                familiares.Property(p => p.Parentesco).IsRequired();
                familiares.Property(p => p.Apellidos).IsRequired(true);
                familiares.Property(p => p.Genero).IsRequired().HasDefaultValue(Genero.undefined);
                familiares.Property(p => p.Correo).IsRequired(true).HasMaxLength(10);
                familiares.Property(p => p.Nombre).IsRequired(true).HasMaxLength(100);
                familiares.Property(p => p.NumeroTelefono).IsRequired(true).HasMaxLength(10);
                familiares.Ignore(P => P.paciente);
            });

            modelBuilder.Entity<Historia>(historias =>
            {
                historias.ToTable("Historias");
                historias.HasKey(p => p.Id);
                historias.Property(p => p.Diagnostico).IsRequired();
                historias.Property(p => p.Entorno).IsRequired(true);
                historias.HasMany(p => p.SugerenciaCuidado).WithOne(p => p.historia).HasForeignKey(p => p.Id);
                historias.Ignore(P => P.paciente);
            });

            modelBuilder.Entity<Medico>(medicos =>
            {
                medicos.ToTable("Medicos");
                medicos.HasKey(p => p.Id);
                medicos.Property(p => p.Especialidad).IsRequired();
                medicos.Property(p => p.Codigo).IsRequired();
                medicos.Property(p => p.Apellidos).IsRequired(true);
                medicos.Property(p => p.Genero).IsRequired().HasDefaultValue(Genero.undefined);
                medicos.Property(p => p.RegistroRethus).IsRequired(true).HasMaxLength(10);
                medicos.Property(p => p.Nombre).IsRequired(true).HasMaxLength(100);
                medicos.Property(p => p.NumeroTelefono).IsRequired(true).HasMaxLength(10);
                medicos.Ignore(P => P.paciente);
            });

            modelBuilder.Entity<SignoVital>(signosVitales =>
            {
                signosVitales.ToTable("Signos Vitales");
                signosVitales.HasKey(p => p.Id);
                signosVitales.Property(p => p.FechaHora).IsRequired().HasDefaultValue(DateTime.Now);
                signosVitales.Property(p => p.Signo).IsRequired();
                signosVitales.Property(p => p.Valor).IsRequired(true);
                signosVitales.Ignore(P => P.paciente);
                signosVitales.HasOne(p => p.paciente).WithMany(p => p.SignosVitales).HasForeignKey(p => p.pacienteId);
            });

            modelBuilder.Entity<SugerenciaCuidado>(sugerenciasCuidados =>
            {
                sugerenciasCuidados.ToTable("Sugerencias de Cuidado");
                sugerenciasCuidados.HasKey(p => p.Id);
                sugerenciasCuidados.Property(p => p.FechaHora).IsRequired().HasDefaultValue(DateTime.Now);
                sugerenciasCuidados.Property(p => p.Descripcion).IsRequired();
                sugerenciasCuidados.Ignore(P => P.historia);
            });
        }
    }
}