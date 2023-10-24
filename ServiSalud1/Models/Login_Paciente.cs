using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.Models
{
    public class Login_Paciente
    {
        [Required]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
