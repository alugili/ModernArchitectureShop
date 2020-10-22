using System.Threading;
using System.Threading.Tasks;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernArchitectureShop.Store.Infrastructure.UseCases.CreateProduct;
using ModernArchitectureShop.Store.Infrastructure.UseCases.DeleteProduct;

namespace ModernArchitectureShop.StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSubscriberController : ControllerBase
    {
        [Topic("ProductCreated", "ProductCreated")]
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

        [Topic("ProductDeleted", "ProductDeleted")]
        [HttpPost("ProductDeleted")]
        public async Task SubcribeProductDeleted(
                     DeleteProduct command,
                     [FromServices] IMediator mediator,
                     CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
        }
    }
}
