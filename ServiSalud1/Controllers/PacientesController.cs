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

        public IActionResult Crear(Pacientes pacientes)
        {
                objPac.Pacientes.Add(pacientes);
                objPac.SaveChanges();
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var paciente = objPac.Pacientes.FirstOrDefault(c => c.Id_pacientes == id);
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Pacientes paciente)
        {
                objPac.Pacientes.Update(paciente);
                objPac.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var paciente = objPac.Pacientes.FirstOrDefault(c => c.Id_pacientes == id);
            if (paciente != null)
            {
                objPac.Pacientes.Remove(paciente);
                objPac.SaveChanges();
            }
            return RedirectToAction("Index");
            /*objPac.Pacientes.Remove(paciente);
            objPac.SaveChanges();
            return RedirectToAction("Index");*/
        }
    }
}

