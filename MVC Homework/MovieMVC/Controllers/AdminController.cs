using Microsoft.AspNetCore.Mvc;

namespace MovieMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
