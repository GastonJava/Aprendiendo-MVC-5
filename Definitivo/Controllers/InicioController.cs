namespace Definitivo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class InicioController : Controller
    {
        [AllowAnonymous]
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
