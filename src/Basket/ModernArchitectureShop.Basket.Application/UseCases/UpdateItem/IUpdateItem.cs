using System;

namespace ModernArchitectureShop.Basket.Application.UseCases.UpdateItem
{
    public interface IUpdateItem
    {
        public Guid ProductId { get; }
        public string NewProductName { get; }
    }
}
