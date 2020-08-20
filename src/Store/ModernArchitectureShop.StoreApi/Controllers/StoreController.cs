using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.StoreApi.Application.UseCases.AddOrUpdateProductStore;
using ModernArchitectureShop.StoreApi.Application.UseCases.CreateStore;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("add-or-update-product")]
        public async Task<IActionResult> AddOrUpdateProduct([FromBody] AddOrdUpdateProductStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
