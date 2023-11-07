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

        public IActionResult Registrar(UsuarioViewModel u)
        {
            var nuevoRegistroUsuario = new Usuario
            {
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Id_Usuario = u.Id_Usuario,
                Contra = u.Contra,
                TipoUsuario = u.TipoUsuario
            };
            if (u.Nombre != null && u.Apellido != null && u.Id_Usuario != null && u.Contra != null && u.TipoUsuario != null)
            {
                
                if (u.Id_empleado != null)
                {
                    var id_empleado = objUsu.Empleados.FirstOrDefault(e => e.Id_empleado == u.Id_empleado);
                    if (id_empleado != null)
                    {
                        objUsu.Usuario.Add(nuevoRegistroUsuario);
                        objUsu.SaveChanges();
                        return RedirectToAction("Login", "Acceso");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    objUsu.Usuario.Add(nuevoRegistroUsuario);
                    objUsu.SaveChanges();
                    return RedirectToAction("Login", "Acceso");
                }
                
            }
            else { return View(); }
        }     
        
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           return RedirectToAction("Login", "Acceso");
        }
    }
}

