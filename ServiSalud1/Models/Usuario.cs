using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.Models
{
    public class Usuario
    {
        [Key]
        public string Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contra { get; set; }
        public string TipoUsuario { get; set; }   

    }
}
