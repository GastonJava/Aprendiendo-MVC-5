using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Definitivo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Definitivo.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult RolesView()
        {

            var roles = _roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult CrearRoles() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRoles(CrearRoleM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole {
                    Name = model.RoleName
                };

               IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded) 
                {
                    return RedirectToAction("RolesView", "Roles");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string id) 
        {
            if (ModelState.IsValid)
            {

                var rol = await _roleManager.FindByIdAsync(id);

                if (rol == null)
                {
                    ViewBag.ErrorMessage = $"el usuario con el rol id = {id} / no se encuentra";
                    return View("No se encuentra");
                }

                var model = new CrearRoleM
                {
                   Id = rol.Id,
                   RoleName = rol.Name
                };

                foreach (var user in _userManager.Users) 
                {
                    if (await _userManager.IsInRoleAsync(user, rol.Name)) 
                    {
                        model.Users.Add(user.UserName);
                    }
                }

                return View(model);

                //IdentityResult identresult = await _roleManager.UpdateAsync(id); 

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CrearRoleM model)
        {
            if (ModelState.IsValid)
            {

                var rol = await _roleManager.FindByIdAsync(model.Id);

                if (rol == null)
                {
                    ViewBag.ErrorMessage = $"el usuario con el rol id = {model.Id} / no se encuentra";
                    return View("No se encuentra");
                }
                else
                {
                    rol.Name = model.RoleName;
                    var result = await _roleManager.UpdateAsync(rol);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("RolesView");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);


                    }

                    return View(model);
                }

            }

            return View();
        }
    }
}