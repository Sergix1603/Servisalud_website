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
            Builder.Entity<Equipo_produccion>().HasData(
                    new Equipo_produccion() { Id_equipo = 220, Nombre_equipo = "Esfingomanometro" },
                    new Equipo_produccion() { Id_equipo = 221, Nombre_equipo = "Termostato" },
                    new Equipo_produccion() { Id_equipo = 222, Nombre_equipo = "Rayos X" },
                    new Equipo_produccion() { Id_equipo = 223, Nombre_equipo = "Guantes Latex" },
                    new Equipo_produccion() { Id_equipo = 224, Nombre_equipo = "Ultra sonido" },
                    new Equipo_produccion() { Id_equipo = 225, Nombre_equipo = "Estetoscopio" },
                    new Equipo_produccion() { Id_equipo = 226, Nombre_equipo = "Tensiometro Aneroide" },
                    new Equipo_produccion() { Id_equipo = 227, Nombre_equipo = "Sillones reclinables" },
                    new Equipo_produccion() { Id_equipo = 228, Nombre_equipo = "Computadora" },
                    new Equipo_produccion() { Id_equipo = 229, Nombre_equipo = "Bascula" }
                );
            Builder.Entity<Servicios>().HasData(
                    new Servicios() { Id_serv = 7001, Nom_serv = "Urgencias", Id_equipo = 220},
                    new Servicios() { Id_serv = 7002, Nom_serv = "Pediatria", Id_equipo = 221},
                    new Servicios() { Id_serv = 7003, Nom_serv = "Radiografias", Id_equipo = 222},
                    new Servicios() { Id_serv = 7004, Nom_serv = "Dermatologia", Id_equipo = 223},
                    new Servicios() { Id_serv = 7005, Nom_serv = "Terapia", Id_equipo = 224},
                    new Servicios() { Id_serv = 7006, Nom_serv = "Medicina General", Id_equipo = 225},
                    new Servicios() { Id_serv = 7007, Nom_serv = "Ambulancias", Id_equipo = 226},
                    new Servicios() { Id_serv = 7008, Nom_serv = "Psicologia", Id_equipo = 227},
                    new Servicios() { Id_serv = 7009, Nom_serv = "Ventanilla", Id_equipo = 228},
                    new Servicios() { Id_serv = 7010, Nom_serv = "Triaje", Id_equipo = 229}
                );
            Builder.Entity<Clinica>().HasData(
                    new Clinica() { Id_Clinica = 101, Nombre_clinica= "SERVISALUD CESPEDES", Ubicacion = "Tomaykichwa"},
                    new Clinica() { Id_Clinica = 102, Nombre_clinica = "SERVISALUD CESPEDES", Ubicacion = "Lima" }
                );
            Builder.Entity<Clinica_servicios>().HasData(
                    new Clinica_servicios() { Id_Clinica_servicios = 111, Id_clinica = 101, Id_serv = 7001},
                    new Clinica_servicios() { Id_Clinica_servicios = 112, Id_clinica = 101, Id_serv = 7002},
                    new Clinica_servicios() { Id_Clinica_servicios = 113, Id_clinica = 101, Id_serv = 7005},
                    new Clinica_servicios() { Id_Clinica_servicios = 114, Id_clinica = 101, Id_serv = 7006},
                    new Clinica_servicios() { Id_Clinica_servicios = 115, Id_clinica = 101, Id_serv = 7007},
                    new Clinica_servicios() { Id_Clinica_servicios = 116, Id_clinica = 101, Id_serv = 7009},
                    new Clinica_servicios() { Id_Clinica_servicios = 117, Id_clinica = 101, Id_serv = 7010},
                    new Clinica_servicios() { Id_Clinica_servicios = 118, Id_clinica = 102, Id_serv = 7001},
                    new Clinica_servicios() { Id_Clinica_servicios = 129, Id_clinica = 102, Id_serv = 7002},
                    new Clinica_servicios() { Id_Clinica_servicios = 120, Id_clinica = 102, Id_serv = 7003},
                    new Clinica_servicios() { Id_Clinica_servicios = 121, Id_clinica = 102, Id_serv = 7004},
                    new Clinica_servicios() { Id_Clinica_servicios = 122, Id_clinica = 102, Id_serv = 7005},
                    new Clinica_servicios() { Id_Clinica_servicios = 123, Id_clinica = 102, Id_serv = 7006},
                    new Clinica_servicios() { Id_Clinica_servicios = 124, Id_clinica = 102, Id_serv = 7007},
                    new Clinica_servicios() { Id_Clinica_servicios = 125, Id_clinica = 102, Id_serv = 7008},
                    new Clinica_servicios() { Id_Clinica_servicios = 126, Id_clinica = 102, Id_serv = 7009},
                    new Clinica_servicios() { Id_Clinica_servicios = 127, Id_clinica = 102, Id_serv = 7010}
                );
            Builder.Entity<Especialidad>().HasData(
                    new Especialidad() { Id_especialidad = 4120, Especialidad_nombre = "Reumatología" },
                    new Especialidad() { Id_especialidad = 4121, Especialidad_nombre = "Dermatología" },
                    new Especialidad() { Id_especialidad = 4122, Especialidad_nombre = "Enfermería" },
                    new Especialidad() { Id_especialidad = 4123, Especialidad_nombre = "Cardiología" },
                    new Especialidad() { Id_especialidad = 4124, Especialidad_nombre = "Nutrición" },
                    new Especialidad() { Id_especialidad = 4125, Especialidad_nombre = "Endocrinología" },
                    new Especialidad() { Id_especialidad = 4126, Especialidad_nombre = "Neurología" },
                    new Especialidad() { Id_especialidad = 4127, Especialidad_nombre = "Traumatología" },
                    new Especialidad() { Id_especialidad = 4128, Especialidad_nombre = "Terapia" },
                    new Especialidad() { Id_especialidad = 4129, Especialidad_nombre = "Psicología" }
                );
            Builder.Entity<Empleados>().HasData(
                    new Empleados() { Id_empleado = 202001, Nombre_empleado = "Carlos", Apellido_empleado = "Vasquez", Id_especialidad = 4121, Id_Clinica = 102, Sexo = "M", Telefono = 941449558, Nacimiento = new DateTime(1990, 5, 15) },
                    new Empleados() { Id_empleado = 202002, Nombre_empleado = "Luis", Apellido_empleado = "Quispe", Id_especialidad = 4120, Id_Clinica = 101, Sexo = "M", Telefono = 941449544, Nacimiento = new DateTime(1981, 7, 8) },
                    new Empleados() { Id_empleado = 202003, Nombre_empleado = "Ernesto", Apellido_empleado = "Vargas", Id_especialidad = 4122, Id_Clinica = 102, Sexo = "M", Telefono = 941446411, Nacimiento = new DateTime(1975, 1, 11) },
                    new Empleados() { Id_empleado = 202004, Nombre_empleado = "Juan", Apellido_empleado = "Contreras", Id_especialidad = 4123, Id_Clinica = 102, Sexo = "M", Telefono = 941449542, Nacimiento = new DateTime(1980, 10, 9) },
                    new Empleados() { Id_empleado = 202005, Nombre_empleado = "Ruben", Apellido_empleado = "Hurtado", Id_especialidad = 4124, Id_Clinica = 101, Sexo = "M", Telefono = 941449526, Nacimiento = new DateTime(1971, 2, 1) }
                );
            Builder.Entity<Citas>().HasData(
                    new Citas() { Id_citas = 9621, Fechas_citas = new DateTime(2023, 1, 25), Id_empleado = 202001}
                );
            Builder.Entity<Historial_clinico>().HasData(
                    new Historial_clinico() { Id_historial = 851, Fecha_ingreso = new DateTime(2023, 1, 15), Alergias = "Aines", Ultimo_ritmo_cardiaco_X_minuto = 75, Estado_cardiaco = "Estable"}
                );
            Builder.Entity<Pacientes>().HasData(
                    new Pacientes() { Id_pacientes = 15020, DNI = "76543210", Nombre = "Sergio", Apellido = "Bustamante", Telefono = "987654321", Correo = "sergioB@gmail.com", Sexo = "M", Edad = 19, Direccion = "Calle La Libertad 124, La Molina", Id_historial = 851}
                );
            Builder.Entity<Historial_citas>().HasData(
                    new Historial_citas() { ID_Historial_citas = 401, Id_historial = 851, Id_citas = 9621}
                );
        }
    }

}
