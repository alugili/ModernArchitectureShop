using System;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }  = string.Empty;
        public double Price { get; set; }
    }
}
