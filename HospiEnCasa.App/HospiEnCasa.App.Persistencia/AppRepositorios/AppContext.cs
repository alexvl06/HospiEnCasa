using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;


namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }
        public DbSet<FamiliarDesignado> FamiliaresDesignados { get; set; }
        public DbSet<SignoVital> SignosVitales { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<SugerenciaCuidado> SugerenciasCuidados { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-33TAF8JP;Initial Catalog=HospiEnCasaDB");
            }
        }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Paciente>(patient =>
            {
                patient.ToTable("Pacientes");
                patient.HasKey(p => p.Id);
                patient.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                patient.Property(p => p.Apellidos).IsRequired().HasMaxLength(150);
                patient.Property(p => p.Direccion).IsRequired().HasMaxLength(150);
                patient.Property(p => p.Genero).IsRequired();
                patient.HasOne(p => p.FamiliarDesignado).WithOne(p => p.paciente).HasForeignKey<FamiliarDesignado>(p => p.PacienteId);
                patient.Property(p => p.FechaNacimiento).IsRequired();
                patient.Property(p => p.Latitud).IsRequired(false);
                patient.Property(p => p.Longitud).IsRequired(false);
                patient.Property(p => p.NumeroTelefono).IsRequired(true);
                patient.Property(p => p.Ciudad);
                patient.HasOne(p => p.Historia).WithOne(p => p.paciente).HasForeignKey<Historia>(p => p.PacienteId);
                patient.HasOne(p => p.Medico).WithMany(p => p.pacientes).HasForeignKey(p => p.MedicoId);


            });


            modelBuilder.Entity<FamiliarDesignado>(familiares =>
            {
                familiares.ToTable("Familiares");
                familiares.HasKey(p => p.Id);
                familiares.Property(p => p.Parentesco).IsRequired();
                familiares.Property(p => p.Apellidos).IsRequired(true);
                familiares.Property(p => p.Genero).IsRequired();
                familiares.Property(p => p.Correo).IsRequired(true).HasMaxLength(100);
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
                historias.Ignore(P => P.paciente);
            });

            modelBuilder.Entity<Medico>(medicos =>
            {
                medicos.ToTable("Medicos");
                medicos.HasKey(p => p.Id);
                medicos.Property(p => p.Especialidad).IsRequired();
                medicos.Property(p => p.Codigo).IsRequired().HasMaxLength(10);
                medicos.Property(p => p.Apellidos).IsRequired(true);
                medicos.Property(p => p.Genero).IsRequired();
                medicos.Property(p => p.RegistroRethus).IsRequired(true).HasMaxLength(20).IsFixedLength(true);
                medicos.Property(p => p.Nombre).IsRequired(true).HasMaxLength(100);
                medicos.Property(p => p.NumeroTelefono).IsRequired(true).HasMaxLength(10);
                medicos.Ignore(P => P.pacientes);
            });

            modelBuilder.Entity<SignoVital>(signosVitales =>
            {
                signosVitales.ToTable("Signos Vitales");
                signosVitales.HasKey(p => p.Id);
                signosVitales.Property(p => p.FechaHora).IsRequired();
                signosVitales.Property(p => p.Signo).IsRequired();
                signosVitales.Property(p => p.Valor).IsRequired(true);
                signosVitales.Ignore(P => P.paciente);
                signosVitales.HasOne(p => p.paciente).WithMany(p => p.SignosVitales).HasForeignKey(p => p.pacienteId);
            });

            modelBuilder.Entity<SugerenciaCuidado>(sugerenciasCuidados =>
            {
                sugerenciasCuidados.ToTable("Sugerencias de Cuidado");
                sugerenciasCuidados.HasKey(p => p.Id);
                sugerenciasCuidados.Property(p => p.FechaHora).IsRequired();
                sugerenciasCuidados.Property(p => p.Descripcion).IsRequired();
                sugerenciasCuidados.HasOne(p => p.historia).WithMany(p => p.SugerenciaCuidado).HasForeignKey(p => p.HistoriaId);
                sugerenciasCuidados.Ignore(P => P.historia);
            });
        }
    }
}