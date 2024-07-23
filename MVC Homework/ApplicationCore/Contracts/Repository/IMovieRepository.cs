using ApplicationCore.Entity;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository: IRepository<Movies>
    {
        Task<IEnumerable<Movies>> GetHighestGrossingMovies();
        Task<Movies> GetMovieById(int id);
        Task<Movies> GetMovieDetails(int id);
        Task<PaginatedResultSet<Movies>> GetMoviesByGenre(int genreId, int pageIndex, int pageSize);
    }
}
