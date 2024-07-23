using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Model;
using ApplicationCore.Model.RequestModel;
using ApplicationCore.Model.ResponseModel;
using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }
        public IEnumerable<MovieCardModel> GetAllMovieCards()
        {
            return new List<MovieCardModel>
            {
                new MovieCardModel { Id = 1, Title = "Movie 1",Description = "This is Movie 1", PosterUrl = "" },
                new MovieCardModel { Id = 2, Title = "Movie 2",Description = "This is Movie 2", PosterUrl = "" },
                new MovieCardModel { Id = 3, Title = "Movie 3",Description = "This is Movie 3", PosterUrl = "" }
            };
        }

        int IMovieService.AddMovie(MovieRequest movieRequestModel)
        {
            return (this._movieRepository.Insert(new Movies
            {
                Budget = movieRequestModel.Budget,
                Title = movieRequestModel.Title,
                BackdropUrl = movieRequestModel.BackdropUrl,
                CreatedBy = movieRequestModel.CreatedBy,
                CreatedDate = movieRequestModel.CreatedDate,
                ImdbUrl = movieRequestModel.ImdbUrl,
                OriginalLanguage = movieRequestModel.OriginalLanguage,
                Overview = movieRequestModel.Overview,
                PosterUrl = movieRequestModel.PosterUrl,
                Price = movieRequestModel.Price,
                ReleaseDate = movieRequestModel.ReleaseDate,
                Revenue = movieRequestModel.Revenue,
                RunTime = movieRequestModel.RunTime,
                TagLine = movieRequestModel.TagLine,
                TmdbUrl = movieRequestModel.TmdbUrl,
                UpdatedBy = movieRequestModel.UpdatedBy,
                UpdatedDate = movieRequestModel.UpdatedDate,
                MovieGenres = movieRequestModel.MovieGenres,
                Trailers = movieRequestModel.Trailers,
                MovieCasts = movieRequestModel.MovieCasts,
                Reviews = movieRequestModel.Reviews,
                Favorites = movieRequestModel.Favorites,
                Purchases = movieRequestModel.Purchases
            }));
        }

        int IMovieService.DeleteMovie(int id)
        {
            return _movieRepository.Delete(id);
        }

        async Task<IEnumerable<MovieResponse>> IMovieService.GetAllMovies()
        {
            var movies = await _movieRepository.GetAll();
            List<MovieResponse> movieResponses = new List<MovieResponse>();

            foreach(var m in movies)
            {
                movieResponses.Add(new MovieResponse
                {
                    Id = m.Id,
                    Budget = m.Budget,
                    Title = m.Title,
                    BackdropUrl = m.BackdropUrl,
                    CreatedBy = m.CreatedBy,
                    CreatedDate = m.CreatedDate,
                    ImdbUrl = m.ImdbUrl,
                    OriginalLanguage = m.OriginalLanguage,
                    Overview = m.Overview,
                    PosterUrl = m.PosterUrl,
                    Price = m.Price,
                    ReleaseDate = m.ReleaseDate,
                    Revenue = m.Revenue,
                    RunTime = m.RunTime,
                    TagLine = m.TagLine,
                    TmdbUrl = m.TmdbUrl,
                    UpdatedBy = m.UpdatedBy,
                    UpdatedDate = m.UpdatedDate,
                    MovieGenres = m.MovieGenres,
                    Trailers = m.Trailers,
                    MovieCasts = m.MovieCasts,
                    Reviews = m.Reviews,
                    Favorites = m.Favorites,
                    Purchases = m.Purchases
                });
            }
            return movieResponses;
        }

        async Task<IEnumerable<MovieResponse>> IMovieService.GetHighestGrossingMovies()
        {
            var movies = await this._movieRepository.GetHighestGrossingMovies();
            List<MovieResponse> movieResponses = new List<MovieResponse>();
            foreach (var m in movies)
            {
                movieResponses.Add(new MovieResponse
                {
                    Id = m.Id,
                    Budget = m.Budget,
                    Title = m.Title,
                    BackdropUrl = m.BackdropUrl,
                    CreatedBy = m.CreatedBy,
                    CreatedDate = m.CreatedDate,
                    ImdbUrl = m.ImdbUrl,
                    OriginalLanguage = m.OriginalLanguage,
                    Overview = m.Overview,
                    PosterUrl = m.PosterUrl,
                    Price = m.Price,
                    ReleaseDate = m.ReleaseDate,
                    Revenue = m.Revenue,
                    RunTime = m.RunTime,
                    TagLine = m.TagLine,
                    TmdbUrl = m.TmdbUrl,
                    UpdatedBy = m.UpdatedBy,
                    UpdatedDate = m.UpdatedDate,
                    MovieGenres = m.MovieGenres,
                    Trailers = m.Trailers,
                    MovieCasts = m.MovieCasts,
                    Reviews = m.Reviews,
                    Favorites = m.Favorites,
                    Purchases = m.Purchases
                });
            }
            return movieResponses;

        }

        async Task<MovieResponse> IMovieService.GetMovieById(int id)
        {
            var movie = await this._movieRepository.GetMovieById(id);
            if (movie != null)
            {
                return (new MovieResponse
                {
                    Id = id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    BackdropUrl = movie.BackdropUrl,
                    CreatedBy = movie.CreatedBy,
                    CreatedDate = movie.CreatedDate,
                    ImdbUrl = movie.ImdbUrl,
                    OriginalLanguage = movie.OriginalLanguage,
                    Overview = movie.Overview,
                    PosterUrl = movie.PosterUrl,
                    Price = movie.Price,
                    ReleaseDate = movie.ReleaseDate,
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    TagLine = movie.TagLine,
                    TmdbUrl = movie.TmdbUrl,
                    UpdatedBy = movie.UpdatedBy,
                    UpdatedDate = movie.UpdatedDate,
                    MovieGenres = movie.MovieGenres,
                    Trailers = movie.Trailers,
                    MovieCasts = movie.MovieCasts,
                    Reviews = movie.Reviews,
                    Favorites = movie.Favorites,
                    Purchases = movie.Purchases
                });
            }
            return null;
        }

        int IMovieService.UpdateMovie(MovieRequest movieRequestModel, int id)
        {
            return (this._movieRepository.Update(new Movies
            {
                Id = id,
                Budget = movieRequestModel.Budget,
                Title = movieRequestModel.Title,
                BackdropUrl = movieRequestModel.BackdropUrl,
                CreatedBy = movieRequestModel.CreatedBy,
                CreatedDate = movieRequestModel.CreatedDate,
                ImdbUrl = movieRequestModel.ImdbUrl,
                OriginalLanguage = movieRequestModel.OriginalLanguage,
                Overview = movieRequestModel.Overview,
                PosterUrl = movieRequestModel.PosterUrl,
                Price = movieRequestModel.Price,
                ReleaseDate = movieRequestModel.ReleaseDate,
                Revenue = movieRequestModel.Revenue,
                RunTime = movieRequestModel.RunTime,
                TagLine = movieRequestModel.TagLine,
                TmdbUrl = movieRequestModel.TmdbUrl,
                UpdatedBy = movieRequestModel.UpdatedBy,
                UpdatedDate = movieRequestModel.UpdatedDate,
                MovieGenres = movieRequestModel.MovieGenres,
                Trailers = movieRequestModel.Trailers,
                MovieCasts = movieRequestModel.MovieCasts,
                Reviews = movieRequestModel.Reviews,
                Favorites = movieRequestModel.Favorites,
                Purchases = movieRequestModel.Purchases
            }));
        }

        public async Task<Movies> GetMovieDetails(int id)
        {
            return await this._movieRepository.GetMovieDetails(id);
        }


        public async Task<PaginatedResultSet<MovieResponse>> GetMoviesByGenre(int genreId, int pageIndex, int pageSize)
        {
            var paginatedMovies = await _movieRepository.GetMoviesByGenre(genreId, pageIndex, pageSize);
            var movieResponses = paginatedMovies.Data.Select(m => new MovieResponse
            {
                Id = m.Id,
                Budget = m.Budget,
                Title = m.Title,
                BackdropUrl = m.BackdropUrl,
                CreatedBy = m.CreatedBy,
                CreatedDate = m.CreatedDate,
                ImdbUrl = m.ImdbUrl,
                OriginalLanguage = m.OriginalLanguage,
                Overview = m.Overview,
                PosterUrl = m.PosterUrl,
                Price = m.Price,
                ReleaseDate = m.ReleaseDate,
                Revenue = m.Revenue,
                RunTime = m.RunTime,
                TagLine = m.TagLine,
                TmdbUrl = m.TmdbUrl,
                UpdatedBy = m.UpdatedBy,
                UpdatedDate = m.UpdatedDate,
                MovieGenres = m.MovieGenres,
                Trailers = m.Trailers,
                MovieCasts = m.MovieCasts,
                Reviews = m.Reviews,
                Favorites = m.Favorites,
                Purchases = m.Purchases
            }).ToList();

            return new PaginatedResultSet<MovieResponse>(movieResponses, paginatedMovies.TotalCount, pageIndex, pageSize);
        }
    }
}
