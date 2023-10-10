using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Pacientes
    {
        [Key]
        public int Id_pacientes { get; set; }
        [MaxLength(8)]
        public string DNI { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }

        [MaxLength(9)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Correo { get; set; }

        [MaxLength(1)]
        public string Sexo { get; set; }

        public DateTime Nacimiento { get; set; }

        [MaxLength(90)]
        public string Direccion { get; set; }

        [ForeignKey("Historial_clinico")]
        public int Id_historial { get; set; } public Historial_clinico Historial_clinico { get; set; }
    }
}
