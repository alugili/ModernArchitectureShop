using System.Threading.Tasks;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModernArchitectureShop.StoreApi.Application.UseCases.CreateProduct;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StoreSubscriberController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StoreSubscriberController> _logger;

        public StoreSubscriberController(IMediator mediator, ILogger<StoreSubscriberController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Topic("ProductCreated")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            _logger.LogInformation($"Received Products - {command.ProductId}");

            var result = await _mediator.Send(command);

            _logger.LogInformation($"[{nameof(StoreSubscriberController)}] - Create a new product : {result.ProductId}");

            return Ok();
        }
    }
}
