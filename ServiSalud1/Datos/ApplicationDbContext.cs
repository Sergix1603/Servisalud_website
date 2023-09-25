using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;


namespace ServiSalud1.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions
            <ApplicationDbContext> options)
            : base(options) { 
        }
        //ESCRIBIR LOS MODELOS
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<Clinica_servicios> Clinica_servicios { get; set; }
        public DbSet<Equipo_produccion> Equipo_produccion { get; set; }
        public DbSet<Historial_citas> Historial_citas { get; set; }
        public DbSet<Historial_clinico> Historial_Clinico { get; set; }
        public DbSet<Servicios> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer("Server=AJ_LAPTOP;Database=ServiSaludDatabase;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Clinica>().HasData(
                new Clinica() { Id_Clinica = 101, Nombre_clinica= "SERVISALUD CESPEDES", Ubicacion = "Tomaykichwa"},
                new Clinica() { Id_Clinica = 102, Nombre_clinica = "SERVISALUD CESPEDES", Ubicacion = "Lima" }
                );
        }
    }

}
