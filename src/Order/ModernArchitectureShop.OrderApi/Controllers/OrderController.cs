using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Order.Infrastructure.UseCases.AddOrder;

namespace ModernArchitectureShop.OrderApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
