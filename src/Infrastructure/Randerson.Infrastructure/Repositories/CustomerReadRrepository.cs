using System.Collections.Generic;
using System.Linq;
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
            return Client.Find(client => client.Id == id);
        }

        public List<Domain.Entities.Customer> get() =>
            Client.FindAll(client => true).ToList();

        public Domain.Entities.Customer Insert(Domain.Entities.Customer user)
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
