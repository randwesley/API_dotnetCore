using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        //[HttpGet("{name}/{email}")]
        //[ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        //public async Task<ActionResult> FindCustomer([FromRoute] string name, string email, CancellationToken cancellation)
        //{
        //  var request = new FindCustomerRequest(name, email);
        //  var response = await Mediator.Send(request);
        //  return Ok(response);
        //}

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> SaveCustomer([FromBody]  CreateCustomerRequest request, CancellationToken cancellation)
        {
            var response = await Mediator.Send(request, cancellation);
            return Ok(response);
        }

       // [HttpPut("update")]
       // [AllowAnonymous]
       // [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
       // [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
       // public async Task<ActionResult> UpdateMenu([FromBody] UpdateCustomerRequest request, CancellationToken cancellation)
       // {
       //     var response = await Mediator.Send(request, cancellation);
       //     return Ok(response);
       // }
    }
}