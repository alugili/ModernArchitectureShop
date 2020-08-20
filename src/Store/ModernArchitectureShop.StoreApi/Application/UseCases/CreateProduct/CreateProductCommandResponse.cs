using System;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
    }
}
