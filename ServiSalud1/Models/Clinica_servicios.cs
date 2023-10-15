using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiSalud1.Models
{
    public class Clinica_servicios
    {
       [Key]
       public int Id_Clinica_servicios { get; set; }  
       [ForeignKey("Clinica")]
       public int Id_clinica { get; set; } 

       [ForeignKey("Servicios")]
       public int Id_serv { get; set; }
       public Clinica Clinica { get; set; }
       public Servicios Servicios { get; set; }
    }
}
