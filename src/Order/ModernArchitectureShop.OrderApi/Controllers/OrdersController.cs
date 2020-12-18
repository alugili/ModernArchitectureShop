using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Order.Infrastructure.UseCases.GetCompletedOrders;

namespace ModernArchitectureShop.OrderApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet("completedorders")]
        public async Task<IActionResult> GetCompletedOrders([FromQuery] GetCompletedOrdersCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
