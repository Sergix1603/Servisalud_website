using System.ComponentModel.DataAnnotations;
namespace ServiSalud1.Models
{
    public class Especialidad
    {
        [Key]
        public int Id_especialidad { get; set; }

        [MaxLength(50)]
        public string Especialidad_nombre { get; set; }
    }
}
