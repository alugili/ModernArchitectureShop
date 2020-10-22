using System;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.CreateProduct;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>, ICreateProduct
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
