using Microsoft.AspNetCore.Mvc;
using ServiSalud1.Models;
using ServiSalud1.Datos;

namespace ServiSalud1.Controllers
{
    public class Login_EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Login_EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Login_Empleado model)
        {
            if (ModelState.IsValid)
            {
                // Realiza la lógica de autenticación aquí.
                // Verifica el nombre de usuario y la contraseña en la base de datos u otro método de autenticación y realiza las acciones necesarias.

                // Ejemplo de verificación de credenciales, asumiendo que tienes una entidad de empleados en tu base de datos.
                var empleado = _context.Login_Empleado.FirstOrDefault(e => e.Usuario == model.Usuario && e.Contraseña == model.Contraseña);

                if (empleado != null)
                {
                    // Iniciar sesión exitosa; redirige a la página de inicio del empleado.
                    return RedirectToAction("Inicio", "Empleado");
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
