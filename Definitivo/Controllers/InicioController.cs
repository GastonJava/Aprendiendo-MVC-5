namespace Definitivo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="InicioController" />
    /// </summary>
    public class InicioController : Controller
    {
        /// <summary>
        /// The Inicio
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [Authorize]
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
