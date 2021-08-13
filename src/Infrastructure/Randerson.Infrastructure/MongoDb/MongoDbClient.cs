using MongoDB.Bson;
using MongoDB.Driver;
using Randerson.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Randerson.Infrastructure.MongoDb
{
    public class MongoDbClient<T, TId>
        where T : BaseEntity<TId>

    {
        private MongoClient Client { get; }
        private IMongoCollection<T> Collection { get; }
        private string connectionString;

        public MongoDbClient(MongoConfig settings)
        {
            Client = new MongoClient(settings.ConnectionString);
            Collection = Client.GetDatabase(settings.DatabaseName).GetCollection<T>(settings.CollectionName);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return (T)Collection.Find(expression).FirstOrDefault();
        }

        public MongoDbClient(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).ToList();
        }

        public T InsertOne(T data)
        {
            Collection.InsertOne(data);
            return data;
        }


        public bool Update(TId id, T input)
        {
            // Logger.LogInformation($"MongoDB: Updating item with id '{id}'");
            input.Id = id;
            var changesDocument = BsonDocument.Parse(input.ToJson());
            var filter = Builders<T>.Filter.Eq("_id", id);
            var firstElement = changesDocument.FirstOrDefault();
            if (Find(i => i.Id.Equals(id)) != null)
            {
                var update = Builders<T>.Update.Set(firstElement.Name, firstElement.Value);
                foreach (var item in changesDocument)
                {
                    if (!item.Value.IsBsonNull && item.Name != "_id")
                    {
                        update = update.Set(item.Name, item.Value);
                    }
                }
                var result = Collection.UpdateOne(filter, update);
                //   Logger.LogInformation($"MongoDB: Updated item with id '{id}'");
                return result.IsAcknowledged;
            }
            else
            {
                //   Logger.LogInformation($"MongoDB: '{id}' could not be updated");
                return false;
            }
        }


        public bool Remove(TId id)
        {
            return Collection.DeleteOne(data => data.Id.Equals(id)).DeletedCount > 0;
        }




        public static implicit operator MongoDbClient<T, TId>(MongoClient v)
        {
            throw new NotImplementedException();
        }
    }
}