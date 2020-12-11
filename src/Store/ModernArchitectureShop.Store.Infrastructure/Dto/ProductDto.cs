using System;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class ProductDto
    {
        public ProductDto(Guid productId, string name, string code, double price, string imageUrl, int quantity, bool canPurchase, Guid storeId)
        {
            ProductId = productId;
            Name = name;
            Code = code;
            Price = price;
            ImageUrl = imageUrl;
            Quantity = quantity;
            CanPurchase = canPurchase;
            StoreId = storeId;
        }

        public Guid ProductId { get; }
        public string Name { get; }
        public string Code { get; }
        public double Price { get; }
        public string ImageUrl { get; }
        public int Quantity { get; }
        public bool CanPurchase { get; }
        public Guid StoreId { get; }
    }
}
