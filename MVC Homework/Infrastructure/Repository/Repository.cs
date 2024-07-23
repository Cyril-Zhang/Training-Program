using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MovieShopDbContext movieShopDbContext;

        public Repository(MovieShopDbContext movieShopDbContext)
        {
            this.movieShopDbContext = movieShopDbContext;
        }

        public virtual int Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                movieShopDbContext.Set<T>().Remove(entity);
                return movieShopDbContext.SaveChanges();
            }

            return 0;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return movieShopDbContext.Set<T>()?.ToList();
        }

        public virtual T? GetById(int id)
        {
            return movieShopDbContext.Set<T>().Find(id);
        }

        public virtual int Insert(T entity)
        {
            movieShopDbContext.Set<T>().Add(entity);
            return movieShopDbContext.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            movieShopDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
            return movieShopDbContext.SaveChanges();
        }
    }
}
