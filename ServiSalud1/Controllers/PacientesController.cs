using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class PacientesController : Controller
    {
        public readonly ApplicationDbContext objCat;
        public PacientesController(ApplicationDbContext dbContext)
        {
            objCat = dbContext;
        }
        public IActionResult Index()
        {

            List<Pacientes> listaPacientes = objCat.Pacientes.ToList();
            return View(listaPacientes);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Pacientes Pacientes)
        {
            if (ModelState.IsValid)
            {
                objCat.Pacientes.Add(Pacientes);
                objCat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

