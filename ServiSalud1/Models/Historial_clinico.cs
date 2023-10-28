using System.ComponentModel.DataAnnotations;

namespace ServiSalud1.Models
{
    public class Historial_clinico
    {
        [Key]
        public int Id_historial { get; set; }

        public DateTime Fecha_ingreso { get; set; }

        [MaxLength(50)]
        public string Alergias { get; set; }

        public List<Citas> Citas { get; set; }

        public Pacientes Pacientes { get; set; }
    }
}
