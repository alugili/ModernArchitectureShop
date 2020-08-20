using System;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ItemModel
    {
        public Guid ItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl   {get;set;}
        public string Username { get; set; }
        public Guid StoreId { get; set; }
    }
}
