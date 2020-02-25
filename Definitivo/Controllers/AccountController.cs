using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Definitivo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PrimerWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _usermanager = userManager;
            _signInManager = signInManager;

        }


        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registrar(UsuarioModelCustom model)
        {

            if (ModelState.IsValid) {              

                try {

                    var user = new IdentityUser {
                        Email = model.Email,
                        UserName = model.NombreUsuario,
                        PasswordHash = model.PasswordHash,
                      
                    };
                    var result = await _usermanager.CreateAsync(user, model.PasswordHash);

                    if (result.Succeeded)
                    {

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex) {
                    return View(ex.Message);
                }

               
            }

            return View();

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


    }
}