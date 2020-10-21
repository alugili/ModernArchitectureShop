using System;

namespace ModernArchitectureShop.Store.Application.UseCases.CreateProduct
{
    public interface ICreateProduct
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
