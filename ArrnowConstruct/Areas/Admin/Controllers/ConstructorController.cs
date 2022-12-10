using ArrnowConstruct.Areas.Admin.Models;
using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.User;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Admin.Controllers
{
    public class ConstructorController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;
        private readonly IConstructorService constructorService;
        private readonly IClientService clientService;

        public ConstructorController(
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
            //var userInfo = await userService.GetUserById(model.User.Id);

            //model.User.Phone = userInfo.Phone;
            //model.User.ProfilePictureUrl = userInfo.ProfilePictureUrl;
            //model.User.Address = userInfo.Address;
            //model.User.City = userInfo.City;
            //model.User.Country = userInfo.Country;
            //model.User.Email = userInfo.Email;
            //model.User.FirstName = userInfo.FirstName;
            //model.User.LastName = userInfo.LastName;

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
                return RedirectToAction("All", "Admin");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
    }
}
