using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.Models
{
    public class Equipo_produccion
    {
        [Key]
        public int Id_equipo { get; set; }

        [MaxLength(50)]
        public string Nombre_equipo { get; set; }
    
        public List<Servicios> Servicios { get; set; }
    }
}
