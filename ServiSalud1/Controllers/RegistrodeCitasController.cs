using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;
using ServiSalud1.ViewModels;

namespace ServiSalud1.Controllers
{
    public class RegistrodeCitasController : Controller
    {
        public readonly ApplicationDbContext objRegCit;
        public RegistrodeCitasController(ApplicationDbContext dbContext)
        {
            objRegCit = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(RegistrodeCitasViewModel RegCita)
        {
            if (ModelState.IsValid)
            {
                var especialidad = objRegCit.Especialidad.FirstOrDefault(e => 
                                   e.Especialidad_nombre == RegCita.Especialidad_nombre);
                var paciente = objRegCit.Pacientes.FirstOrDefault(p =>
                                   p.DNI == RegCita.DNI);
                var nuevaCita = new Citas
                {
                    Fechas_citas = RegCita.Fechas_citas,
                    Id_especialidad = especialidad.Id_especialidad,
                    Id_historial = paciente.Id_historial
                };
                objRegCit.Citas.Add(nuevaCita);
                objRegCit.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
