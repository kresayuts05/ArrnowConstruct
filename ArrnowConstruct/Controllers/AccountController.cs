using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Profile;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IClientService clientService;
        private readonly IImageService imageService;

        public AccountController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            IClientService _clientService,
            IImageService _imageService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            clientService = _clientService;
            imageService = _imageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                Country = model.Country
            };

            var result = await userManager.CreateAsync(user, model.Password);
            await userManager
                  .AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirsName, user.FirstName ?? user.Email));

            await userManager.AddToRoleAsync(user, "Client");
            await clientService.Create(user.Id);

            user.ProfilePictureUrl = await this.imageService.UploadImage(model.ProfilePicture, "images", user);
            await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                if (user.IsActive)
                {

                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
