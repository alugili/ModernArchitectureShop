using System;

namespace ModernArchitectureShop.Basket.Application.UseCases.AddItem
{
    public interface IAddItem
    {
        public Guid ItemId { get; }
        public string Name { get; }
        public string Code { get; }
        public double? Price { get; }
        public string ImageUrl { get; }
        public int Quantity { get; }
        public string Username { get; }
        public Guid StoreId { get; }
    }
}
