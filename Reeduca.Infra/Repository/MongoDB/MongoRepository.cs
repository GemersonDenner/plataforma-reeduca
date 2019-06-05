using MongoDB.Driver;
using Reeduca.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeduca.Infra.Repository.MongoDB
{
    public abstract class MongoRepository<T> : IMongoRepository<T> where T : class, IEntityMongo
    {
        public MongoContext context;
        public IMongoCollection<T> collection;
        public MongoRepository(MongoContext context)
        {
            this.context = context;
            this.collection = Collection();
        }

        private IMongoCollection<T> Collection()
        {
            return this.context.GetDatabase().GetCollection<T>(typeof(T).Name);
        }

        public T Get(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            return this.collection.Find(filter).FirstOrDefault();
        }

        public T Get(string Id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, Id);
            return this.collection.Find(filter).FirstOrDefault();
        }

        public async Task<T> GetAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            var findResult = await this.collection.FindAsync(filter);
            return await findResult.FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(string Id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, Id);
            var findResult = await this.collection.FindAsync(filter);
            return await findResult.FirstOrDefaultAsync();
        }

        public List<T> List()
        {
            return this.collection.Find(x => true).ToList();
        }

        public async Task<List<T>> ListAsync()
        {
            var resultFind = await this.collection.FindAsync(x => true);
            return await resultFind.ToListAsync();
        }

        public T Insert(T entity)
        {
            this.collection.InsertOne(entity);
            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await this.collection.InsertOneAsync(entity);
            return entity;
        }

        public List<T> Insert(List<T> entities)
        {
            this.collection.InsertMany(entities);
            return entities;
        }

        public async Task<List<T>> InsertAsync(List<T> entities)
        {
            await this.collection.InsertManyAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            this.collection.ReplaceOne(filter, entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await this.collection.ReplaceOneAsync(filter, entity);
            return entity;
        }

        public List<T> Update(List<T> entity)
        {
            entity.ForEach(f => { Update(f); });
            return entity;
        }

        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            this.collection.DeleteOne(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await this.collection.DeleteOneAsync(filter);
        }

        public bool Exists(Func<T, bool> predicate)
        {
            return this.collection.AsQueryable().Where(predicate).Any();
        }

        public T Get(Func<T, bool> predicate)
        {
            return this.collection.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public List<T> List(Func<T, bool> predicate)
        {
            return this.collection.AsQueryable().Where(predicate).ToList();
        }

        public void Delete(Func<T, bool> predicate)
        {
            var itensExistentes = this.collection.AsQueryable().Where(predicate).ToList();
            itensExistentes.ForEach(x =>
            {
                this.Delete(x);
            });
        }
    }
}
