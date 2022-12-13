using ArrnowConstruct.Core.Constants;
using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Profile;
using ArrnowConstruct.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IPostService postService;
        private readonly IConstructorService constructorService;
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public ProfileController(IPostService _postService,
            IConstructorService _constructorService,
            IUserService _userService,
            IProfileService _profileService)
        {
            postService = _postService;
            constructorService = _constructorService;
            userService = _userService;
            profileService = _profileService;
        }

        public async Task<IActionResult> MyProfile()
        {
            try
            {
                bool isConstructor = false;

                if (this.User.IsInRole(RoleConstants.Constructor))
                {
                    isConstructor = true;
                }

                var myProfile = await profileService.MyProfile(User.Id(), isConstructor);
                myProfile.Role = RoleConstants.Administrator;

                return View("MyProfile", myProfile);
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("MyProfile", "Profile", new { area = "Admin" });
            }

        }


        public async Task<IActionResult> AnothersProfile([FromRoute] string id)
        {
            try
            {
                bool isConstructor = false;

                if (await constructorService.ExistsById(id))
                {
                    isConstructor = true;
                }

                var myProfile = await profileService.MyProfile(id, isConstructor);
                myProfile.Role = (isConstructor == true) ? RoleConstants.Constructor : RoleConstants.Client;

                return View("MyProfile", myProfile);
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return this.RedirectToAction("All", "User", new { area = "Admin" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            try
            {
                var user = await userService.GetUserById(User.Id());

                var model = new EditViewModel()
                {
                    Id = user.Id,
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

                return this.RedirectToAction("MyProfile", "Profile", new { area = "Admin" });
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

                return this.RedirectToAction("MyProfile", "Profile", new { area = "Admin" });
            }


        }
    }
}
