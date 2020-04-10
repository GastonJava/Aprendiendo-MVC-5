using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Definitivo.Controllers
{
    public class GaleriaController : Controller
    {

        [AllowAnonymous]
        public IActionResult Galeria()
        {
            return View();
        }
    }
}