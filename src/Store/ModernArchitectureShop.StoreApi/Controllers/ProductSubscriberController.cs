using System.Threading;
using System.Threading.Tasks;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.StoreApi.Application.UseCases.CreateProduct;
using ModernArchitectureShop.StoreApi.Application.UseCases.DeleteProduct;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSubscriberController : ControllerBase
    {
        [Topic("ProductCreated")]
        [HttpPost("ProductCreated")]
        public async Task SubcribeProductCreated(CreateProductCommand command, [FromServices] IMediator mediator)
        {
            await mediator.Send(command);
        }

        //[Topic("product-updated")]
        //[HttpPost("product-updated")]
        //public async Task SubcribeProductUpdated(
        //    Todo command,
        //    [FromServices] IMediator mediator)
        //{
        //    await mediator.Send(command);
        //}

        [Topic("ProductDeleted")]
        [HttpPost("ProductDeleted")]
        public async Task SubcribeProductDeleted(
                     DeleteProductCommand command,
                     [FromServices] IMediator mediator,
                     CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
        }
    }
}
