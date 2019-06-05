using Reeduca.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Reeduca.Infra.Repository.EntityFramework
{
    public abstract class EFRepository<T> : IEFRepository<T> where T : class
    {
        public EFContext context;
        public EFRepository(EFContext context)
        {
            this.context = context;
        }

        public void Delete(Func<T, bool> predicate)
        {
            var foundItens = this.context.Set<T>().Where(predicate);
            this.context.Set<T>().RemoveRange(foundItens);
            this.context.SaveChanges();
        }

        public bool Exists(Func<T, bool> predicate)
        {
            return this.context.Set<T>().Any(predicate);
        }

        public T Get(Func<T, bool> predicate)
        {
            return this.context.Set<T>().FirstOrDefault(predicate);
        }

        public T Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public List<T> Insert(List<T> entities)
        {
            this.context.Set<T>().AddRange(entities);
            this.context.SaveChanges();
            return entities;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            this.context.SaveChanges();
            return entity;
        }

        public async Task<List<T>> InsertAsync(List<T> entities)
        {
            await this.context.Set<T>().AddRangeAsync(entities);
            this.context.SaveChanges();
            return entities;
        }

        public List<T> List()
        {
            return this.context.Set<T>().ToList();
        }

        public List<T> List(Func<T, bool> predicate)
        {
            return this.context.Set<T>().Where(predicate).ToList();
        }

        public async Task<List<T>> ListAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }
    }
}
