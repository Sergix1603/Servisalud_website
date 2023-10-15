using System.ComponentModel.DataAnnotations;
namespace ServiSalud1.Models
{
    public class Clinica
    {
        [Key]
        public int Id_Clinica { get; set; }

        [MaxLength(30)]
        public string Nombre_clinica { get; set; }

        [MaxLength(30)]
        public string Ubicacion { get; set; }

        public ICollection<Clinica_servicios> Clinica_Servicios { get; set; }
    }
}
