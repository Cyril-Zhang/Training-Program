using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T entity);
        int Delete(int id);
        int Update(T entity);
        T? GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
