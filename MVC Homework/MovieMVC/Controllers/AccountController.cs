using Microsoft.AspNetCore.Mvc;

namespace MovieMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
