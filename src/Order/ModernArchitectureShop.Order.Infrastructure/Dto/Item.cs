using System;

namespace ModernArchitectureShop.Order.Infrastructure.Dto
{
    public class ItemDto
    {
        public ItemDto(Guid itemId, string name, string code, double? price, int count)
        {
            ItemId = itemId;
            Name = name;
            Code = code;
            Price = price;
            Count = count;
        }

        public Guid ItemId { get; }
        public string Name { get; }
        public string Code { get; }
        public double? Price { get; }
        public int Count { get; }
    }
}
