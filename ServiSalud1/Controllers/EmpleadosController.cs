using Microsoft.AspNetCore.Mvc;

namespace ServiSalud1.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
