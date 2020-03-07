using Microsoft.AspNetCore.Mvc;

namespace Definitivo.Controllers
{
    public class NullController : Controller
    {
        public IActionResult Null()
        {
            return View();
        }
    }
}
