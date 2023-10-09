/*using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace ServiSalud1.Models
{
    public class Clinica_servicios_sc
    {
        [Key]
        public int Id_Clinica_servicios_sc { get; set; }
        public Clinica_servicios Clinica_servicios { get; set; }
        public Clinica Clinica { get; set; }
        public Servicios Servicios { get; set; }
    }
}
@model IEnumerable<ServiSalud1.Models.Clinica_servicios_sc>
@{
    ViewData["Title"] = "Nuestros Servicios";
}

< div class= "text-center" >
    < h1 class= "display-4" > Nuestros Servicios </ h1 >
    < table class= "table" >
        < thead >
            < tr >
                < th >
                    Codigo Servicio
                </ th >
                < th >
                    Servicio
                </ th >
                < th >
                    Sede
                </ th >
            </ tr >
        </ thead >
        < tbody >
            @foreach(var item in Model)
            {
                < tr class= "datos_tabla" >
                    < td >
                        @item.Clinica_servicios.Id_serv
                    </ td >
                    < td >
                        @item.Servicios.Nom_serv
                    </ td >
                    < td >
                        @item.Clinica.Nombre_clinica
                    </ td >
                    < td >
                </ tr >
            }
        </ tbody >
    </ table >
</ div >
