using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Randerson.Application.Commands.CreateCustomer
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}