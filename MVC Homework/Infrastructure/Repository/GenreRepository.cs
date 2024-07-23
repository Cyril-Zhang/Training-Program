using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenreRepository : Repository<Genres>, IGenreRepository

    {
        private MovieShopDbContext _movieShopDbContext;
        public GenreRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
        {
            _movieShopDbContext = movieShopDbContext;
        }
    }
}
