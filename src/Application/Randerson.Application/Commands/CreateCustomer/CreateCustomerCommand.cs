using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Randerson.Domain.Entities;
using Randerson.Domain.Repositories;
using Raven.Client.Exceptions;

namespace Randerson.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private ICustomerReadRepository Repository { get; }

        public CreateCustomerCommand(ICustomerReadRepository repository)
        {
            Repository = repository;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer customerFind = Repository.Find(request.Name, request.Email);
            if (customerFind?.Id.ToString().Length > 0)
            {
                throw new Exception("Customer already exists in the base");
            }
            var customer = new Customer()
            {
                Name = request.Name,
                Email = request.Email
            };
            var responseCustomer = Repository.InsertOne(customer);

            var response = new CreateCustomerResponse(responseCustomer);
            return await Task.FromResult(response);
        }
    }
}