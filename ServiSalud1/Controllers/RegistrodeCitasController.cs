using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;
using ServiSalud1.ViewModels;

namespace ServiSalud1.Controllers
{
    public class RegistrodeCitasController : Controller
    {
        public readonly ApplicationDbContext objRegCit;
        public RegistrodeCitasController(ApplicationDbContext dbContext)
        {
            objRegCit = dbContext;
        }
        [HttpGet]
        public IActionResult ObtenerFechaHora()
        {
            try
            {
                var fechaHora = DateTime.Now.ToString("dd-MM-yyyy / HH:mm:ss");
                return Json(new { fechaHora });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Json(new { error = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Obtener la lista de especialidades desde la base de datos
            var especialidades = objRegCit.Especialidad.ToList();

            // Crear una lista de SelectListItem para usar en la vista
            ViewBag.Especialidades = especialidades
                .Select(e => new SelectListItem { Value = e.Especialidad_nombre, Text = e.Especialidad_nombre })
                .ToList();

            // Obtener el nombre de la especialidad seleccionada (si hay una seleccionada)
            string especialidadSeleccionada = Request.Query["especialidad"];

            // Filtrar empleados por la especialidad seleccionada
            var empleados = objRegCit.Empleados.ToList();

            if (!string.IsNullOrEmpty(especialidadSeleccionada))
            {
                empleados = empleados
                    .Where(e => e.Especialidad.Especialidad_nombre == especialidadSeleccionada)
                    .ToList();
            }

            // Crear una lista de SelectListItem para usar en la vista
            ViewBag.Empleados = empleados
                .Select(e => new SelectListItem { Value = e.Nombre_empleado, Text = $"{e.Nombre_empleado} - {e.Especialidad.Especialidad_nombre}" })
                .ToList();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(RegistrodeCitasViewModel RegCita)
        {
            if (ModelState.IsValid)
            {
                var especialidad = objRegCit.Especialidad.FirstOrDefault(e => 
                                   e.Especialidad_nombre == RegCita.Especialidad_nombre);
                var paciente = objRegCit.Pacientes.FirstOrDefault(p =>
                                   p.DNI == RegCita.DNI);
                var nuevaCita = new Citas
                {
                    Fechas_citas = RegCita.Fechas_citas,
                    Id_especialidad = especialidad.Id_especialidad,
                    Id_historial = paciente.Id_historial
                };
                objRegCit.Citas.Add(nuevaCita);
                objRegCit.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
