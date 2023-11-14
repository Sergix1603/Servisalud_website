using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

            var listaEmpleados = objEmp.Empleados
            .Include(e => e.Especialidad)
            .Include(e => e.Clinica)
            .ToList();
            return View(listaEmpleados);
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Crear()
        {
            var especialidades = objEmp.Especialidad.ToList();
            ViewBag.Especialidades = new SelectList(especialidades, "Id_especialidad", "Especialidad_nombre");
            var clinicas = objEmp.Clinica.Select(c => new { Id_Clinica = c.Id_Clinica, Ubicacion = c.Ubicacion }).ToList();
            ViewBag.Clinicas = new SelectList(clinicas, "Id_Clinica", "Ubicacion");

            return View();
        }
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var empleado = objEmp.Empleados.FirstOrDefault(c => c.Id_empleado == id);
            // Cargar las ubicaciones de las clínicas
            ViewBag.Clinicas = objEmp.Clinica
                .Select(c => new SelectListItem { Value = c.Id_Clinica.ToString(), Text = c.Ubicacion })
                .ToList();

            // Cargar los nombres de las especialidades
            ViewBag.Especialidades = objEmp.Especialidad
                .Select(e => new SelectListItem { Value = e.Id_especialidad.ToString(), Text = e.Especialidad_nombre })
                .ToList();
            return View(empleado);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Empleados empleado)
        {
            if (ModelState.IsValid)
            {
                objEmp.Empleados.Update(empleado);
                objEmp.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var empleado = objEmp.Empleados.FirstOrDefault(
                c => c.Id_empleado == id);
            objEmp.Empleados.Remove(empleado);
            objEmp.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

