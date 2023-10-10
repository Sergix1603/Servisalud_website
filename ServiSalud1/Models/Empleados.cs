using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Empleados
    {
        [Key]
        public int Id_empleado { get; set; }
        [MaxLength(60)]
        public string Nombre_empleado { get; set; }

        [ForeignKey("Especialidad")] 
        public int Id_especialidad { get; set; } public Especialidad Especialidad { get; set; }
        
        [ForeignKey("Clinica")]
        public int Id_Clinica { get; set; } public Clinica Clinica { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}
