using ServiSalud1.Models;
using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.ViewModels
{
    public class RegistrodePacienteViewModel
    {
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

        [MaxLength(4)]
        public string Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nacimiento { get; set; }
        [MaxLength(3)]
        public Double Peso { get; set; }
        [MaxLength(3)]
        public Double Altura { get; set; }
        [MaxLength(100)]
        public string Antecedentes { get; set; }
        [MaxLength(100)]
        public string Motivo { get; set; }
        [MaxLength(90)]
        public string Direccion { get; set; }

        public int Id_historial { get; set; }

        public DateTime Fecha_ingreso { get; set; }

        [MaxLength(50)]
        public string Alergias { get; set; }
        
    }
}
