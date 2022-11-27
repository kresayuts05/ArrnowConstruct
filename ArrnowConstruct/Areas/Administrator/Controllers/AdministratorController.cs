using Microsoft.AspNetCore.Mvc;

namespace ArrnowConstruct.Areas.Administrator.Controllers
{
    public class AdministratorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
