namespace ServiSalud1.Models
{
    public class Clinica_servicios_sc
    {
        public int Id_Clinica_servicios_sc { get; set; }
        public Clinica_servicios Clinica_servicios { get; set; }
        public Clinica Clinica { get; set; }
        public Servicios Servicios { get; set; }
    }
}
