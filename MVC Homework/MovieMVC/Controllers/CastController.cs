using ApplicationCore.Contracts.Service;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var cast = _castService.GetCastDetails(id);
            if (cast == null)
            {
                return NotFound();
            }
            return View(cast);
        }
    }
}
