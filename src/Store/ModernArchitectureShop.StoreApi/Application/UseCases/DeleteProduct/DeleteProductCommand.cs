using System;
using MediatR;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
    }
}
