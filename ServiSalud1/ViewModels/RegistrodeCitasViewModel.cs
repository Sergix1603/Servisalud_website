using System.ComponentModel.DataAnnotations;
namespace ServiSalud1.ViewModels
{
    public class RegistrodeCitasViewModel
    {
        [MaxLength(8)]
        public string DNI { get; set; }

        [MaxLength(50)]
        public string Especialidad_nombre { get; set; }

        [MaxLength(60)]
        public string Nombre_empleado { get; set; }

        public DateTime Fechas_citas { get; set; }

        [MaxLength(30)]
        public string Ubicacion { get; set; }
    }
}
