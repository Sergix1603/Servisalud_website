using System.ComponentModel.DataAnnotations;
namespace ServiSalud1.Models
{
    public class Clinica
    {
        [Key]
        public int Id_Clinica { get; set; }
        public string Nombre_clinica { get; set; }
        public string Ubicacion { get; set; }
    }
}
