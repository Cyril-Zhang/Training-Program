using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movies>, IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;
        public MovieRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
        {
            this._movieShopDbContext = movieShopDbContext;
        }

        public async Task<IEnumerable<Movies>> GetHighestGrossingMovies()
        {
            return await this._movieShopDbContext.Movies
            .OrderByDescending(m => m.Revenue).ToListAsync();
        }

        public async Task<Movies> GetMovieById(int id)
        {
            return await this._movieShopDbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCasts)
                    .ThenInclude(mc => mc.Cast)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Movies> GetMovieDetails(int id)
        {
            return await this._movieShopDbContext.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieCasts)
                    .ThenInclude(mc => mc.Cast)
                .Include(m => m.Trailers)
                .Include(m => m.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PaginatedResultSet<Movies>> GetMoviesByGenre(int genreId, int pageIndex, int pageSize)
        {
            var totalMovies = await _movieShopDbContext.Movies
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
                .CountAsync();

            var movies = await _movieShopDbContext.Movies
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
                .OrderBy(m => m.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResultSet<Movies>(movies, totalMovies, pageIndex, pageSize);
        }
    }
}