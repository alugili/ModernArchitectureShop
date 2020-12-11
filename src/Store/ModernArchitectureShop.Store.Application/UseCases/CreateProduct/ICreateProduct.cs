using System;

namespace ModernArchitectureShop.Store.Application.UseCases.CreateProduct
{
    public interface ICreateProduct
    {
        public Guid ProductId { get; }
        public string Code { get; }
        public string Name { get; }
        public double Price { get; }
        public string ImageUrl { get; }
    }
}
