using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.ShopUI.Models
{
    public class ItemsModel
    {
        public int TotalOfItems { get; set; }
        public ICollection<ItemModel> Items { get; set; } = new Collection<ItemModel>();
    }
}
