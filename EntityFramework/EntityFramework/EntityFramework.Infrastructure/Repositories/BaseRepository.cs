using EntityFramework.Core.Interfaces.Repositories;
using EntityFramework.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T: class
{
    private EfDemoDbContext _dbContext = new EfDemoDbContext();
    
    public int Insert(T obj)
    {
        _dbContext.Set<T>().Add(obj);
        _dbContext.SaveChanges();
        return 1;
    }

    public int DeleteById(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return 1;
        }

        return 0;
    }

    public int Update(T obj)
    {
        _dbContext.Entry(obj).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return 1;
    }

    public T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }
}