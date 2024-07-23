using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CastRepository : Repository<Casts>, ICastRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;
        public CastRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
        {
            _movieShopDbContext = movieShopDbContext;
        }
        public override Casts GetById(int id)
        {
            return _movieShopDbContext.Casts
                .Include(c => c.MovieCasts)
                    .ThenInclude(mc => mc.Movie)
                .FirstOrDefault(c => c.Id == id);

        }
    }
}
