using System.Collections.ObjectModel;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ItemsModel
    {
        public int TotalOfItems { get; set; }
        public Collection<ItemModel> Items { get; set; } = new Collection<ItemModel>();
    }
}
