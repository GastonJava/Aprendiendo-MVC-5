namespace PrimerWeb.Controllers
{
    using Definitivo.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    //[Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar(UsuarioModelCustom model)
        {

            if (ModelState.IsValid)
            {

                try
                {

                    var user = new IdentityUser
                    {
                        Email = model.Email,
                        UserName = model.NombreUsuario,
                        PasswordHash = model.PasswordHash,

                    };
                    var result = await _usermanager.CreateAsync(user, model.PasswordHash);

                    if (result.Succeeded)
                    {

                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("login", "account");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {


            //var identityResult = await _signInManager.PasswordSignInAsync("nuevo", "nuevo", false, lockoutOnFailure: false);

            //if (identityResult.Succeeded)
            //{
            //    return RedirectToAction("Inicio", "inicio");
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioModelCustom model)
        {
            //if (ModelState.IsValid)
            //{

            try
            {

                var usuario = await _usermanager.FindByNameAsync(model.NombreUsuario);
                var password = await _usermanager.CheckPasswordAsync(user: usuario, model.PasswordHash);


                if (password)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(user: usuario, model.PasswordHash, false, lockoutOnFailure: false);

                    var claims = User.Claims.ToList();


                    // EDIT: ver por que no recibe ningun tipo de claims
                    // EDIT: el usuario se logea pero no me permite identificar el estado del usuario

                    if (identityResult.Succeeded)
                    {
                        return RedirectToAction("Inicio", "inicio");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return BadRequest();
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout(UsuarioModelCustom model)
        //{
        //    var role = await _usermanager.FindByIdAsync(model.Id);

        //    return View(model);
        //}
        public async Task<IActionResult> Salir()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
