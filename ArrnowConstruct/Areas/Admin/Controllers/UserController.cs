using ArrnowConstruct.Areas.Admin.Models;
using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Extensions;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;
        private readonly IConstructorService constructorService;
        private readonly IClientService clientService;

        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            IConstructorService _constructorService,
            IClientService _clientService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            constructorService = _constructorService;
            clientService = _clientService;
        }


        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsers(this.User.Id());

            return View(model);
        }

        public async Task<IActionResult> Clients()
        {
            var model = await clientService.GetAllClients(this.User.Id());

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Approve(string id)
        {
            var user = await userService.GetUserById(id);

            var model = new ConstructorApproveViewModel()
            {
                    Id = id,
                    Phone = user.Phone,
                    Address = user.Address,
                    Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(ConstructorApproveViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await constructorService.Create(model.Id, model.MinimumSalary);

            var user = await userManager.FindByIdAsync(model.Id);

            await userManager.RemoveFromRoleAsync(user, RoleConstants.Client);
            await userManager.AddToRoleAsync(user, RoleConstants.Constructor);
            var result = await userManager.UpdateAsync(user);

            await clientService.DisactivateClient(await clientService.GetClientId(model.Id));

            if (result.Succeeded)
            {
                return RedirectToAction("All", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userService.GetUserById(id);

            var model = new UserDeleteViewModel()
            {
                Id = id,
                FullName = user.FirstName + " " + user.LastName,
                Phone = user.Phone,
                Address = user.Address,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteViewModel model)
        {
            await userService.Delete(model.Id);

            if(await constructorService.ExistsById(model.Id))
            {
                var id = await constructorService.GetConstructorId(model.Id);
                await constructorService.DisactivateConstructor(id);
            }
            else
            {

                var id = await clientService.GetClientId(model.Id);
                await clientService.DisactivateClient(id);
            }

            return RedirectToAction("All", "User");
        }
    }
}
