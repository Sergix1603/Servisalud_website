/*using Microsoft.AspNetCore.Mvc;
using ServiSalud1.Datos;
using ServiSalud1.Models;

namespace ServiSalud1.Controllers
{
    public class Clinica_servicios_scController : Controller
    {
        public readonly ApplicationDbContext objCliServsc;
        public Clinica_servicios_scController(ApplicationDbContext dbContext)
        {
            objCliServsc = dbContext;
        }
        public IActionResult Index()
        {
            List<Clinica_servicios_sc> listaClinica_servicios_sc = objCliServsc.Clinica_servicios_sc.ToList();
            return View(listaClinica_servicios_sc);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Clinica_servicios_sc Clinica_servicios_sc)
        {
            if (ModelState.IsValid)
            {
                objCliServsc.Clinica_servicios_sc.Add(Clinica_servicios_sc);
                objCliServsc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var Clinica_servicios_sc = objCliServsc.Clinica_servicios_sc.FirstOrDefault
                (c => c.Id_Clinica_servicios_sc == id);
            return View(Clinica_servicios_sc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Clinica_servicios_sc Clinica_servicios_sc)
        {
            if (ModelState.IsValid)
            {
                objCliServsc.Clinica_servicios_sc.Update(Clinica_servicios_sc);
                objCliServsc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Clinica_servicios_sc);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var Clinica_servicios_sc = objCliServsc.Clinica_servicios_sc.FirstOrDefault(
                c => c.Id_Clinica_servicios_sc == id);
            objCliServsc.Clinica_servicios_sc.Remove(Clinica_servicios_sc);
            objCliServsc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
