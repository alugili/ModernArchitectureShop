using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.ShopUI.Models
{
    public class OrdersModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = new Collection<OrderModel>();
    }
}
