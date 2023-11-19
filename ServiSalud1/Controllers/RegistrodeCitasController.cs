using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Datos;
using ServiSalud1.Models;
using ServiSalud1.ViewModels;
using System.Diagnostics;

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

        [HttpGet]
        public IActionResult Listado()
        {
            var citas = objRegCit.Citas
                .Include(c => c.Especialidad)
                .Include(c => c.Historial_clinico.Pacientes)
                .ToList();

            return View(citas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCita(int id)
        {
            try
            {
                // Buscar la cita por su ID
                var cita = objRegCit.Citas.Find(id);

                if (cita == null)
                {
                    return NotFound(); // Devuelve un 404 si la cita no se encuentra
                }

                // Eliminar la cita de la base de datos
                objRegCit.Citas.Remove(cita);
                objRegCit.SaveChanges();

                // Redirigir a la acción "Listado" después de eliminar la cita
                return RedirectToAction("Listado");
            }
            catch (Exception ex)
            {
                // Log the exception
                Debug.WriteLine($"Error al intentar eliminar la cita: {ex.Message}");
                return StatusCode(500, "Error interno al intentar eliminar la cita.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegistrodeCitasViewModel RegCita)
        {
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
            if (ModelState.IsValid)
            {
                try
                {
                    // ... (resto del código)

                    var especialidad = objRegCit.Especialidad.FirstOrDefault(e =>
                        e.Especialidad_nombre == RegCita.Especialidad_nombre);

                    var paciente = objRegCit.Pacientes.FirstOrDefault(p =>
                        p.DNI == RegCita.DNI);

                    if (especialidad != null && paciente != null)
                    {
                        var nuevaCita = new Citas
                        {
                            Fechas_citas = RegCita.Fechas_citas,
                            Id_especialidad = especialidad.Id_especialidad,
                            Id_historial = paciente.Id_historial
                        };

                        objRegCit.Citas.Add(nuevaCita);
                        objRegCit.SaveChanges();

                        // Redirección a la acción "Listado" después de guardar la cita
                        return RedirectToAction("Listado");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Especialidad o paciente no encontrados.");
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Debug.WriteLine($"Error al intentar registrar la cita: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Error interno al intentar registrar la cita.");
                }
            }

            // Si el modelo no es válido, regresa a la vista "Index"
            return View();
        }



    }
}
