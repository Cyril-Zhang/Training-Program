using ApplicationCore.Entity;
using ApplicationCore.Model;
using ApplicationCore.Model.RequestModel;
using ApplicationCore.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponse>> GetAllMovies();
        Task<IEnumerable<MovieResponse>> GetHighestGrossingMovies();
        int AddMovie(MovieRequest movieRequestModel);
        int UpdateMovie(MovieRequest movieRequestModel, int id);
        int DeleteMovie(int id);
        Task<MovieResponse> GetMovieById(int id);

        Task<Movies> GetMovieDetails(int id);

        IEnumerable<MovieCardModel> GetAllMovieCards();

        Task<PaginatedResultSet<MovieResponse>> GetMoviesByGenre(int genreId, int pageIndex, int pageSize);
    }
}
