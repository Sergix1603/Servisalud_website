using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Clinica_servicios
    {
        [ForeignKey("Clinica")]
        public int Id_clinica { get; set; } public Clinica Clinica { get; set; }

        [ForeignKey("Servicios")]
        public int Id_serv { get; set; } public Servicios Servicios { get; set; }
    }
}
