using System;

namespace ModernArchitectureShop.Basket.Application.UseCases.AddItem
{
    public interface IAddItem
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        public Guid StoreId { get; set; }
    }
}
