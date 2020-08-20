using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.BasketApi.Application.UseCases.AddItem;
using ModernArchitectureShop.BasketApi.Application.UseCases.DeleteItem;

namespace ModernArchitectureShop.BasketApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] AddItemCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new DeleteItemCommand { ItemId = id });
            return Ok(result);
        }
    }
}
