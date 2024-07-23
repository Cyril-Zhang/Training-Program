using ApplicationCore.Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MovieMVC.ViewComponents
{
    public class GenresViewComponent: ViewComponent
    {
        private readonly IGenreRepository _genreRepository;

        public GenresViewComponent(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreRepository.GetAll();
            return View(genres);
        }
    }
}
