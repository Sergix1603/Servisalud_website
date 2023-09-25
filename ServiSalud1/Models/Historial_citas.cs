using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Historial_citas
    {
        [ForeignKey("Historial_clinico")]
        public int Id_historial { get; set; } public Historial_clinico Historial_Clinico { get; set; }

        [ForeignKey("Citas")]
        public int Id_citas { get; set; } public Citas Citas { get; set; }
    }
}
