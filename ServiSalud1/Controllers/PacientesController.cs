using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;
using ServiSalud1.ViewModels;
using static ServiSalud1.ViewModels.RegistrodePacienteViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using Microsoft.AspNetCore.Authorization;

namespace ServiSalud1.Controllers
{
    
    public class PacientesController : Controller
    {
        public readonly ApplicationDbContext objPac;
        public PacientesController(ApplicationDbContext dbContext)
        {
            objPac = dbContext;
        }
        [Authorize(Roles = "Administrador, Empleado")]
        public IActionResult Index()
        {

            List<Pacientes> listaPacientes = objPac.Pacientes.ToList();
            return View(listaPacientes);
        }
        [Authorize(Roles = "Administrador, Empleado")]
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Empleado")]
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
                    Peso = regpacientes.Peso,
                    Altura = regpacientes.  Altura,
                    Antecedentes = regpacientes.Antecedentes,
                    Id_historial = nuevoIdHistorial
                };

                objPac.Pacientes.Add(paciente);
                objPac.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Administrador, Empleado")]
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
        [Authorize(Roles = "Administrador, Empleado")]
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
        [Authorize(Roles = "Administrador, Empleado")]
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var paciente = objPac.Pacientes.FirstOrDefault(c => c.Id_pacientes == id);
            objPac.Pacientes.Remove(paciente);
            objPac.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador, Empleado")]
        public IActionResult GenerarFichaPDF(int id)
        {
            var paciente = ObtenerDatosDelPaciente(id);

            // Agrega una variable de vista para indicar que es una solicitud de PDF
            ViewData["IsPdfRequest"] = true;

            return new ViewAsPdf("FichaPDFView", paciente)
            {
                FileName = "FichaPaciente.pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                CustomSwitches = "--print-media-type"
            };
        }



        private Pacientes ObtenerDatosDelPaciente(int id)
        {
            // Lógica para obtener los datos del paciente desde tu base de datos
            var paciente = objPac.Pacientes.FirstOrDefault(p => p.Id_pacientes == id);
            return paciente;
        }

        public IActionResult Mostrar(int id)
        {
            var paciente = ObtenerDatosDelPaciente(id);

            // Agrega una variable de vista para indicar que es una solicitud de PDF
            ViewData["IsPdfRequest"] = true;

            return new ViewAsPdf("FichaPDFView", paciente)
            {
                FileName = "FichaPaciente.pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                CustomSwitches = "--print-media-type"
            };
        }


    }
}