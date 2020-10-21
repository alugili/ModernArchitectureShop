using System;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.DeleteProduct;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.DeleteProduct
{
    public class DeleteProduct : IRequest<bool>, IDeleteProduct
    {
        public Guid ProductId { get; set; }
    }
}
