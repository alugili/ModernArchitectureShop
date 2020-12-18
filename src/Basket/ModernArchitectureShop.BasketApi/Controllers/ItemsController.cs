using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Basket.Infrastructure.UseCases.GetBasketTotalPrice;
using ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems;
using ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItemsPage;

namespace ModernArchitectureShop.BasketApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetItemsCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getitemspage")]
        public async Task<IActionResult> GetItemsPage([FromQuery] GetItemsPageCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("totalprice")]
        public async Task<IActionResult> GetTotalPrice([FromQuery] GetBasketTotalPriceCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
