using System.ComponentModel.DataAnnotations;
namespace ServiSalud1.ViewModels
{
    public class ClinicaServiciosViewModel
    {
        [MaxLength(30)]
        public string Nombre_Clinica { get; set; }
        [MaxLength(30)]
        public string Ubicacion { get; set; }
        [MaxLength(50)]
        public string Nombre_Servicio { get; set; }
    }
}
