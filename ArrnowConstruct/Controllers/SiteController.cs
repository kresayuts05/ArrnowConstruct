using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Controllers
{
    public class SiteController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
