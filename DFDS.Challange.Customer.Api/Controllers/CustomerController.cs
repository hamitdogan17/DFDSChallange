using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DFDS.Challange.Customer.API.Controllers
{
    public interface IDispatcher : IMediator
    {
    }
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customerList")]
        //[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCustomersByFilter([FromQuery] Business.Queries.ListOfCustomerByFilter.Request request)
        {
            var customers = await _mediator.Send(request);
            return Ok(customers);
        }

        [HttpGet("getQualifiedCustomerFromCountryRef")]
        //[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCustomersByFilter([FromQuery] Business.Queries.GetQualifiedCustomerFromCountryRef.Request request)
        {
            var customers = await _mediator.Send(request);
            return Ok(customers);
        }

        [HttpPost("createCustomer")]
        //[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateCustomer([FromBody] Business.Commands.CreateCustomer.Request request)
        {
            var customers = await _mediator.Send(request);
            return Ok(customers);
        }

        [HttpPut("updateCustomer")]
        //[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateCustomer([FromBody] Business.Commands.UpdateCustomer.Request request)
        {
            var customers = await _mediator.Send(request);
            return Ok(customers);
        }
        [HttpDelete("deleteCustomer")]
        //[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteCustomer([FromBody] Business.Commands.DeleteCustomer.Request request)
        {
            var customers = await _mediator.Send(request);
            return Ok(customers);
        }
    }
}
