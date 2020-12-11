using System;

namespace ModernArchitectureShop.Store.Application.UseCases.DeleteProduct
{
    public interface IDeleteProduct
    {
        public Guid ProductId { get; }
    }
}
