using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;

namespace ServiSalud1.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext objCat;
        public CategoriasController(ApplicationDbContext dbContext)
        {
            objCat = dbContext;
        }
        public IActionResult Index()
        {
            List<Especialidad> listaEspecialidads = objCat.Especialidad.ToList();
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
                objCat.Especialidad.Add(Especialidad);
                objCat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

