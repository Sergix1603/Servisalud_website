using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiSalud1.Models;
using ServiSalud1.Datos;
using System.Diagnostics.Contracts;
using ServiSalud1.ViewModels;

namespace ServiSalud1.Controllers
{
    public class AccesoController : Controller
    {
        public readonly ApplicationDbContext objUsu;
        public AccesoController(ApplicationDbContext dbContext)
        {
            objUsu = dbContext;
        }
        public IActionResult Login(string Id_Usuario, string Contra)
        {
            var usuario = objUsu.Usuario.FirstOrDefault(item => item.Id_Usuario == Id_Usuario && item.Contra == Contra);
            if (usuario != null)
            {
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
        
        public IActionResult Salir()
        {
           return RedirectToAction("Login", "Acceso");
        }
    }
}

