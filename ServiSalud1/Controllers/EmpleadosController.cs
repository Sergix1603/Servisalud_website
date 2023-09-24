using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class EmpleadosController : Controller
    {
        public readonly ApplicationDbContext objCat;
        public EmpleadosController(ApplicationDbContext dbContext)
        {
            objCat = dbContext;
        }
        public IActionResult Index()
        {

            List<Empleados> listaEmpleados = objCat.Empleados.ToList();
            return View(listaEmpleados);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Empleados Empleados)
        {
            if (ModelState.IsValid)
            {
                objCat.Empleados.Add(Empleados);
                objCat.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

