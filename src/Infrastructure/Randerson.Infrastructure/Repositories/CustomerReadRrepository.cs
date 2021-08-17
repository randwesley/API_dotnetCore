using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using Randerson.Domain.Entities;
using Randerson.Domain.Repositories;
using Randerson.Infrastructure.MongoDb;

namespace Randerson.Infrastructure.Repositories
{
    public class CustomerReadRepository : ICustomerReadRepository
    {

        private MongoDbClient<Domain.Entities.Customer, string> Client { get; }

        public CustomerReadRepository(MongoDbClient<Domain.Entities.Customer, string> client)
        {
            Client = client;
        }

        public Domain.Entities.Customer Find(string id)
        {
            var _id = new ObjectId(id);
            Customer customer = Client.Find(client => client.Id == id);
            return customer;
        }

        public Domain.Entities.Customer Find(string name, string email)
        {
            Customer customer = Client.Find(x => x.Name == name && x.Email == email);
            return customer;
        }

        public List<Domain.Entities.Customer> get() =>
        Client.FindAll(client => true).ToList();

        public Domain.Entities.Customer InsertOne(Domain.Entities.Customer user)
        {
            Client.InsertOne(user);
            return user;
        }

        public bool Update(Domain.Entities.Customer user, string id)
        {
            return Client.Update(id, user);
        }

        public bool Remove(string id)
        {
            return Client.Remove(id);
        }
    }
}
