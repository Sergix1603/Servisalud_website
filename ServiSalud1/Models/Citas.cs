using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Citas
    {
        [Key]
        public int Id_citas { get; set; }

        public DateTime Fechas_citas { get; set; }

        [ForeignKey("Especialidad")]
        public int Id_especialidad { get; set; } public Especialidad Especialidad { get; set; }

        [ForeignKey("Historial_clinico")]
        public int Id_historial { get; set; } public Historial_clinico Historial_clinico { get; set; }
    }
}
