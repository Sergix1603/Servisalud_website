using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;


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
            Builder.Entity<Especialidad>().HasData(
                new Especialidad() { Id_especialidad= 4120, Especialidad_nombre = "Dermatologia"},
                new Especialidad() { Id_especialidad= 4121, Especialidad_nombre = "Pediatria" },
                new Especialidad() { Id_especialidad = 4122, Especialidad_nombre = "Oftalmologia" }
                );
            Builder.Entity<Empleados>().HasData(
                new Empleados() { Id_empleado = 202001, Nombre_empleado = "Carlos", Apellido_empleado = "Vasquez", Id_especialidad = 4121, Id_Clinica = 102, Sexo = "M", Telefono = 941449558, Nacimiento = new DateTime(1990, 5, 15) },
                new Empleados() { Id_empleado = 202002, Nombre_empleado = "Luis", Apellido_empleado = "Quispe", Id_especialidad = 4120, Id_Clinica = 101, Sexo = "M", Telefono = 941449544, Nacimiento = new DateTime(1981, 7, 8) },
                new Empleados() { Id_empleado = 202003, Nombre_empleado = "Ernesto", Apellido_empleado = "Vargas", Id_especialidad = 4122, Id_Clinica = 102, Sexo = "M", Telefono = 941446411, Nacimiento = new DateTime(1975, 1, 11) }

                );
        }
    }

}
