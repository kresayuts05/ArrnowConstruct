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
            var myProfile = await profileService.MyProfile(User.Id());   
            bool isConstructor = await constructorService.ExistsById(User.Id());

            myProfile.IsConstructor = isConstructor;

            return View("Profile", myProfile);
        }


        public async Task<IActionResult> AnothersProfile([FromRoute]string id)
        {
            var myProfile = await profileService.MyProfile(id);
            bool isConstructor = await constructorService.ExistsById(id);

            myProfile.IsConstructor = isConstructor;

            return View("Profile", myProfile);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
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

        [HttpPost]
        public async Task<IActionResult> Edit( EditViewModel model)
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
