using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class EmpleadosController : Controller
    {
        public readonly ApplicationDbContext objEmp;
        public EmpleadosController(ApplicationDbContext dbContext)
        {
            objEmp = dbContext;
        }
        public IActionResult Index()
        {

            List<Empleados> listaEmpleados = objEmp.Empleados.ToList();
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
                objEmp.Empleados.Add(Empleados);
                objEmp.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

