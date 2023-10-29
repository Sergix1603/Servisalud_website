using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;
using ServiSalud1.ViewModels;
using static ServiSalud1.ViewModels.RegistrodePacienteViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

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

        public IActionResult Crear(RegistrodePacienteViewModel regpacientes)
        {
            if (ModelState.IsValid)
            {
                var hiscli = new Historial_clinico
                {
                    Fecha_ingreso = regpacientes.Fecha_ingreso,
                    Alergias = regpacientes.Alergias,
                    Citas = null
                };
                objPac.Historial_Clinico.Add(hiscli);
                objPac.SaveChanges();
                var nuevoIdHistorial = hiscli.Id_historial;

                var paciente = new Pacientes
                {
                    Id_pacientes = regpacientes.Id_pacientes,
                    DNI = regpacientes.DNI,
                    Nombre = regpacientes.Nombre,
                    Apellido = regpacientes.Apellido,
                    Telefono = regpacientes.Telefono,
                    Correo = regpacientes.Correo,
                    Sexo = regpacientes.Sexo,
                    Nacimiento = regpacientes.Nacimiento,
                    Direccion = regpacientes.Direccion,
                    Id_historial = nuevoIdHistorial
                };
                
                objPac.Pacientes.Add(paciente);
                objPac.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
        public IActionResult Editar(Pacientes paciente, Historial_clinico historial)
        {
            if (ModelState.IsValid)
            {
                objPac.Pacientes.Update(paciente);
                objPac.Historial_Clinico.Update(historial);
                objPac.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var paciente = objPac.Pacientes.FirstOrDefault(c => c.Id_pacientes == id);
            objPac.Pacientes.Remove(paciente);
            objPac.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

