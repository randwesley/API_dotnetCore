using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Randerson.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {

        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            // Verifica se o cliente já está cadastrado
            // Valida os dados
            // Insere o cliente
            // Envia E-mail de boas vindas
            var result = new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = "Randerson Reis",
                Email = "rand@rand.com",
                Date = DateTime.Now
            };
            return Task.FromResult(result);
        }
    }
}