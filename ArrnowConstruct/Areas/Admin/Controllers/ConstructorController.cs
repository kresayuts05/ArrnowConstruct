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

        public ConstructorController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager,
            IUserService _userService,
            IConstructorService _constructorService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userService = _userService;
            constructorService = _constructorService;
        }

        [HttpGet]
        public async Task<IActionResult> Approve(string id)
        {
            var user = await userService.GetUserById(id);

            var model = new ConstructorModel()
            {
                User = new UserModel()
                {
                    Id = id,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(ConstructorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await constructorService.Create(model.User.Id);

            var user = await userManager.FindByIdAsync(model.User.Id);

            await userManager.AddToRoleAsync(user, RoleConstants.Constructor);
            var result = await userManager.UpdateAsync(user);

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
