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
		public IActionResult Crear_Especialidad()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Crear_Especialidad(Especialidad Especialidad)
		{
			if (ModelState.IsValid)
			{
				objEsp.Especialidad.Add(Especialidad);
				objEsp.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Editar_Especialidad(int? id)
		{
			if (id == null)
			{
				return View();
			}
			var empleado = objEsp.Especialidad.FirstOrDefault
				(c => c.Id_especialidad == id);
			return View(empleado);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Editar_Especialidad(Especialidad Especialidad)
		{
			if (ModelState.IsValid)
			{
				objEsp.Especialidad.Update(Especialidad);
				objEsp.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(Especialidad);
		}
		[HttpGet]
		public IActionResult Borrar_Especialidad(int? id)
		{
			var empleado = objEsp.Especialidad.FirstOrDefault(
				c => c.Id_especialidad == id);
			objEsp.Especialidad.Remove(empleado);
			objEsp.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}

