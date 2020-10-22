using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Store.Infrastructure.UseCases.GetProducts;
using ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds;
using ModernArchitectureShop.Store.Infrastructure.UseCases.SearchProducts;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("search-products")]
        public async Task<IActionResult> SearchProducts([FromQuery] SearchProductsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("get-by-ids")]
        public async Task<IActionResult> GetProductsByIds([FromBody] GetProductsByIdsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
