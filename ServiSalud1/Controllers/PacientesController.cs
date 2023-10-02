using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class PacientesController : Controller
    {
        public readonly ApplicationDbContext objPac;
        public PacientesController(ApplicationDbContext dbContext)
        {
            objPac = dbContext;
        }
        public IActionResult Index()
        {

            List<Pacientes> listaPacientes = objPac.Pacientes.ToList();
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
                objPac.Pacientes.Add(Pacientes);
                objPac.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

