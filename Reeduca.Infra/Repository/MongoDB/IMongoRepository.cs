using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reeduca.Infra.Repository.MongoDB
{
    public interface IMongoRepository<T> where T : class, IEntityMongo
    {
        T Get(T entity);

        T Get(string Id);

        Task<T> GetAsync(T entity);

        Task<T> GetAsync(string Id);

        List<T> List();

        Task<List<T>> ListAsync();

        T Insert(T entity);

        Task<T> InsertAsync(T entity);

        List<T> Insert(List<T> entities);

        Task<List<T>> InsertAsync(List<T> entities);

        T Update(T entity);

        Task<T> UpdateAsync(T entity);

        List<T> Update(List<T> entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        bool Exists(Func<T, bool> predicate);

        T Get(Func<T, bool> predicate);

        List<T> List(Func<T, bool> predicate);

        void Delete(Func<T, bool> predicate);
    }
}
