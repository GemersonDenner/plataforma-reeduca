using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reeduca.Infra.Repository.EntityFramework
{
    public interface IEFRepository<T> where T : class
    {
        List<T> List();

        Task<List<T>> ListAsync();

        T Insert(T entity);

        Task<T> InsertAsync(T entity);

        List<T> Insert(List<T> entities);

        Task<List<T>> InsertAsync(List<T> entities);

        bool Exists(Func<T, bool> predicate);

        T Get(Func<T, bool> predicate);

        List<T> List(Func<T, bool> predicate);

        void Delete(Func<T, bool> predicate);
    }
}
