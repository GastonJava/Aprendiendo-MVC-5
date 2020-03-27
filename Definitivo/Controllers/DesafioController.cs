using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Definitivo.Controllers
{
    [AllowAnonymous]
    public class DesafioController : Controller
    {
        public IActionResult Resolucion()
        {
            for (int i = 0; i < 10; i++)
            {
                ViewBag.result = $"posicion: {i}";
            }
            return View();
        }
    }
}
