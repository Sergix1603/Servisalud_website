using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;
using ServiSalud1.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ServiSalud1.Controllers
{
    public class AccesoController : Controller
    {
        public readonly ApplicationDbContext objUsu;
        public AccesoController(ApplicationDbContext dbContext)
        {
            objUsu = dbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario u)
        {
            var usuario = objUsu.Usuario.FirstOrDefault(item => item.Id_Usuario == u.Id_Usuario && item.Contra == u.Contra);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Id_Usuario", usuario.Id_Usuario),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else { return View(); }
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioViewModel u)
        {
            var hiscli = new Historial_clinico
            {
                Fecha_ingreso = DateTime.Now,
                Alergias = u.Alergias,
                Citas = null
            };
            objUsu.Historial_Clinico.Add(hiscli);
            objUsu.SaveChanges();
            var nuevoIdHistorial = hiscli.Id_historial;

            var paciente = new Pacientes
            {
                DNI = u.DNI,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Telefono = u.Telefono,
                Correo = u.Correo,
                Sexo = u.Sexo,
                Nacimiento = u.Nacimiento,
                Direccion = u.Direccion,
                Descripcionmedica = u.Descripcionmedica,
                Peso = u.Peso,
                Altura = u.Altura,
                Antecedentes = u.Antecedentes,
                Id_historial = nuevoIdHistorial
            };
            objUsu.Pacientes.Add(paciente);
            objUsu.SaveChanges();
            var nuevoRegistroUsuario = new Usuario
            {
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Id_Usuario = u.Id_Usuario,
                Contra = u.Contra,
                TipoUsuario = "Paciente"
            };
            objUsu.Usuario.Add(nuevoRegistroUsuario);
            objUsu.SaveChanges();
            return RedirectToAction("Login", "Acceso");
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Evitar que el usuario acceda a páginas protegidas al usar el botón "Atrás"
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            return RedirectToAction("Login", "Acceso");
        }

    }
}

