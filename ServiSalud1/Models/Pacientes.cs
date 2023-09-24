using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.Models
{
    public class Pacientes
    {
        [Key]
        public int Id_paciente { get; set; }
        [MaxLength(60)]
        public string Nombre_paciente { get; set; }
        [MaxLength(60)]
        public string Apellido_paciente { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}
