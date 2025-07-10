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
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Correo { get; set; }

        [MaxLength(4)]
        public string Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nacimiento { get; set; }
        

        //Agregue 4 datos mas Atte: Sergio

        [Range(0.01, 999.99, ErrorMessage = "El valor debe estar entre 0.01 y 999.99")]
        public double Peso { get; set; }

        [Range(0.01, 999.99, ErrorMessage = "El valor debe estar entre 0.01 y 999.99")]
        public double Altura { get; set; }

        [MaxLength(100)]
        public string Antecedentes { get; set; }
        [MaxLength(90)]
        public string Direccion { get; set; }

        [MaxLength(1200)]
        public string Descripcionmedica { get; set; }


        [ForeignKey("Historial_clinico")]
        public int Id_historial { get; set; } public Historial_clinico Historial_clinico { get; set; }
    }
}
