using System;

namespace ModernArchitectureShop.Basket.Infrastructure.Dto
{
    public sealed class ItemDto
    {
        public ItemDto(Guid itemId, Guid storeId, Guid productId, string name, string code, double price, string imageUrl, Guid basketId)
        {
            ItemId = itemId;
            StoreId = storeId;
            ProductId = productId;
            Name = name;
            Code = code;
            Price = price;
            ImageUrl = imageUrl;
            BasketId = basketId;
        }

        public Guid ItemId { get; private set; }
        public Guid StoreId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double Price { get; private set; }
        public string ImageUrl { get; private set; }
        public Guid BasketId { get; private set; }
    }
}
