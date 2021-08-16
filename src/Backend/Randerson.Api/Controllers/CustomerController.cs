using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Randerson.Application.Commands.CreateCustomer;
using Randerson.Domain.Entities;

namespace Randerson.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator Mediator { get; set; }

        public CustomerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("{name}/{email}")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> PostCustomer([FromRoute] string name, string email, CancellationToken cancellation)
        {
            var request = new CreateCustomerRequest(name, email);
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> InsertCustomer([FromBody]  Customer customer, CancellationToken cancellation)
        {
            await Mediator.Send(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.Id.ToString() }, customer);
        }
    }
}