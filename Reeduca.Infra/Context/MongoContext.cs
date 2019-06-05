using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Reeduca.Infra.Context
{
    public class MongoContext
    {
        protected readonly IMongoDatabase database = null;

        public MongoContext(string conn, string db)
        {
            var client = new MongoClient(conn);
            if (client != null)
                database = client.GetDatabase(db);

        }

        public IMongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
