using Randerson.Application.Commands.CustomerGeneric;
using Randerson.Domain.Entities;
using System;

namespace Randerson.Application.Commands.CreateCustomer
{
    public class CreateCustomerResponse
    {
        public CustomerResponse Customer { get; set; }

        public CreateCustomerResponse(Customer customer)
        {
            Customer = new CustomerResponse()
            {
                Name = customer.Name,
                Email = customer.Email
            };
        }
    }
}