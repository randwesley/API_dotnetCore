using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Randerson.Application.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> PostCustomer([FromBody] CreateCustomerRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}