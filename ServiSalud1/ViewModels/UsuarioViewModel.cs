using ServiSalud1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contra { get; set; }
        public string TipoUsuario { get; set; }
        public string DNI { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_ingreso { get; set; }

        [MaxLength(50)]
        public string Alergias { get; set; }

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
        public int Id_historial { get; set; }
    }
}
