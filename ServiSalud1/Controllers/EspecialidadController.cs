using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;

namespace ServiSalud1.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext objEsp;
        public CategoriasController(ApplicationDbContext dbContext)
        {
            objEsp = dbContext;
        }
        public IActionResult Index()
        {
            List<Especialidad> listaEspecialidads = objEsp.Especialidad.ToList();
            return View(listaEspecialidads);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Especialidad Especialidad)
        {
            if (ModelState.IsValid)
            {
                objEsp.Especialidad.Add(Especialidad);
                objEsp.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

