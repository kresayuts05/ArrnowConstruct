using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Profile;
using ArrnowConstruct.Extensions;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IRequestService requestService;
        private readonly IClientService clientService;
        private readonly IConstructorService constructorService;
        private readonly ICategoryService categoryService;
        private readonly IProfileService profileService;
        private readonly IPostService postService;
        private readonly IUserService userService;

        public ProfileController(
            IRequestService _requestService,
            IClientService _clientService,
            IConstructorService _constructorService,
            ICategoryService _categoryService,
            IProfileService _profileService,
            IPostService _postService,
            IUserService _userService)
        {
            requestService = _requestService;
            clientService = _clientService;
            constructorService = _constructorService;
            categoryService = _categoryService;
            profileService = _profileService;
            postService = _postService;
            userService = _userService;
        }

        public async Task<IActionResult> MyProfile()
        {
            try
            {
                bool isConstructor = await constructorService.ExistsById(User.Id());
                var myProfile = await profileService.MyProfile(User.Id(), isConstructor);

                myProfile.IsConstructor = isConstructor;

                return View("Profile", myProfile);
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("Index", "Home");
            }
        }


        public async Task<IActionResult> AnothersProfile([FromRoute] string id)
        {
            try
            {
                bool isConstructor = await constructorService.ExistsById(id);
                var myProfile = await profileService.MyProfile(id, isConstructor);

                myProfile.IsConstructor = isConstructor;

                return View("Profile", myProfile);
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("All", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await userService.GetUserById(id);

                var model = new EditViewModel()
                {
                    Id = id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.Phone,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await profileService.Edit(User.Id(), model);

                return RedirectToAction(nameof(MyProfile));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}
