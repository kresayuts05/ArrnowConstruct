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
            var myProfile = await profileService.MyProfile(User.Id());

            return View(myProfile);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
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

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await profileService.Edit(User.Id(), model);

            return RedirectToAction(nameof(MyProfile));
        }
    }
}
