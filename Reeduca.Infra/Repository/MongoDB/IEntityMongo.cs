using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reeduca.Infra.Repository.MongoDB
{
    public interface IEntityMongo
    {
        [BsonId]
        string Id { get; set; }
    }
}
