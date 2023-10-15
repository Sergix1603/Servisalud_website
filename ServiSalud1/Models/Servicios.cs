using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Servicios
    {
        [Key]
        public int Id_serv { get; set; }

        [MaxLength(50)]
        public string Nom_serv { get; set; }

        [ForeignKey("Equipo_produccion")]
        public int Id_equipo { get; set; } public Equipo_produccion Equipo_produccion { get; set; }
        public ICollection<Clinica_servicios> Clinica_Servicios { get; set; }
    }
}
