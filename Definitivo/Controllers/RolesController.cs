using Definitivo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Definitivo.Controllers
{
    [Authorize(Roles = "Admin")]
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
                IdentityRole identityRole = new IdentityRole
                {
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

                    //ViewBag.msj = "Ese rol ya exise";

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

        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {


            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Editar", new { Id = roleId });
                }
            }

            return RedirectToAction("Editar", new { Id = roleId });
        }

        public async Task<IActionResult> Borrarrol(string idrole)
        {

            var role = await _roleManager.FindByIdAsync(idrole);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {idrole} cannot be found";
                return View();
            }
            else
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    RedirectToAction("Editar", "Roles");
                }
                return View();
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
