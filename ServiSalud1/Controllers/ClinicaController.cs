using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class ClinicaController : Controller
    {
        public readonly ApplicationDbContext objCat;
        public ClinicaController(ApplicationDbContext dbContext)
        {
            objCat = dbContext;
        }
        public IActionResult Index()
        {
            
            List<Clinica> listaClinicas = objCat.Clinica.ToList();
            return View(listaClinicas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Clinica Clinica)
        {
            if (ModelState.IsValid)
            {
                objCat.Clinica.Add(Clinica);
                objCat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

