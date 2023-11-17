using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;
using System.Data;

namespace ServiSalud1.Controllers
{
    public class EspecialidadController : Controller
    {
        public readonly ApplicationDbContext objEsp;
        public EspecialidadController(ApplicationDbContext dbContext)
        {
            objEsp = dbContext;
        }
        public IActionResult Index()
        {
			List<Especialidad> listaEspecialidades = objEsp.Especialidad.Include(e => e.Empleados).ToList();
			return View(listaEspecialidades);
		}
        [Authorize(Roles = "Administrador")]
        [HttpGet]
		public IActionResult Crear_Especialidad()
		{
			return View();
		}
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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

