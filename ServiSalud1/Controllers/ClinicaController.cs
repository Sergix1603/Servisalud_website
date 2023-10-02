using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class ClinicaController : Controller
    {
        public readonly ApplicationDbContext objCli;
        public ClinicaController(ApplicationDbContext dbContext)
        {
            objCli = dbContext;
        }
        public IActionResult Index()
        {
            
            List<Clinica> listaClinicas = objCli.Clinica.ToList();
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
                objCli.Clinica.Add(Clinica);
                objCli.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

