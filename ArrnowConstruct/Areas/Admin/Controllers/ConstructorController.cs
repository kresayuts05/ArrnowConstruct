using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Admin.Controllers
{
    public class ConstructorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
