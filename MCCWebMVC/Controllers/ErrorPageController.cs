using Microsoft.AspNetCore.Mvc;

namespace MCCWebMVC.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
