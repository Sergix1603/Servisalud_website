using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contra { get; set; }
        public string TipoUsuario { get; set; }

        public int? Id_empleado { get; set; }
        [MaxLength(8)]
        public string DNI { get; set; }
    }
}
