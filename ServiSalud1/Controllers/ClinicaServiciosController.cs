using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.ViewModels;

namespace ServiSalud1.Controllers
{
    public class ClinicaServiciosController : Controller
    {
        public readonly ApplicationDbContext objCliServ;
        public ClinicaServiciosController(ApplicationDbContext dbContext)
        {
            objCliServ = dbContext;
        }
        public IActionResult Index()
        {
            var viewclinicaservicios = (from cs in objCliServ.Clinica_servicios
                                        join c in objCliServ.Clinica on cs.Id_clinica equals c.Id_Clinica
                                        join s in objCliServ.Servicios on cs.Id_serv equals s.Id_serv
                                        select new ClinicaServiciosViewModel{
                                            Nombre_Clinica = c.Nombre_clinica,
                                            Ubicacion = c.Ubicacion,
                                            Nombre_Servicio = s.Nom_serv
                                         }).ToList();
            return View(viewclinicaservicios);
        }

    }
}
