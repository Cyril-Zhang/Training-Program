using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entity;


namespace MovieMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public async Task<IActionResult> MoviesByGenre(int id, int pageSize = 30, int pageNumber = 1)
        {
            var paginatedMovies = await _movieService.GetMoviesByGenre(id, pageNumber, pageSize);
            return View(paginatedMovies);
        }
    }
}
