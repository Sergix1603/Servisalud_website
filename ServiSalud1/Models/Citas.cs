using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Citas
    {
        [Key]
        public int Id_citas { get; set; }

        public DateTime Fechas_citas { get; set; }


        [ForeignKey("Empleados")]
        public int Id_empleado { get; set; }
        public Empleados Empleados { get; set; }

    }
}
