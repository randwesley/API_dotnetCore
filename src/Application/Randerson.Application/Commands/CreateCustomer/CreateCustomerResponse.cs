using System;
using System.Collections.Generic;
using System.Text;

namespace Randerson.Application.Commands.CreateCustomer
{
    public class CreateCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}