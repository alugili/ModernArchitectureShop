using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStore([FromQuery] GetStoreCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
