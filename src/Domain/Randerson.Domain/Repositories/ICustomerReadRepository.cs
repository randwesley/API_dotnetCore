using Randerson.Domain.Entities;

namespace Randerson.Domain.Repositories
{
    public interface ICustomerReadRepository
    {
        public Customer Find(string customerId);
        public Customer Find(string name, string email);
        public Customer InsertOne(Customer customer);
    }
}
