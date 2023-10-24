using Microsoft.AspNetCore.Mvc;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class Login_PacienteController : Controller
    {
        // Inyecta el contexto de datos de pacientes (ApplicationDbContext) si es necesario.
        private readonly ApplicationDbContext objPac;

        public Login_PacienteController(ApplicationDbContext dbContext)
        {
            objPac = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Login_Paciente model)
        {
            if (ModelState.IsValid)
            {
                // Realiza la lógica de autenticación aquí.
                // Verifica el nombre de usuario y la contraseña en la base de datos u otro método de autenticación y realiza las acciones necesarias.

                // Ejemplo de verificación de credenciales, asumiendo que tienes una entidad de pacientes en tu base de datos.
                var paciente = objPac.Login_Paciente.FirstOrDefault(p => p.Usuario == model.Usuario && p.Contraseña == model.Contraseña);

                if (paciente != null)
                {
                    // Iniciar sesión exitosa; redirige a la página de inicio del paciente.
                    return RedirectToAction("Inicio", "Paciente");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales incorrectas. Inténtalo de nuevo.");
                }
            }

            return View("Index", model);
        }
    }
}
