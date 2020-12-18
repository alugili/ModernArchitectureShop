using System.Collections.Generic;

namespace ModernArchitectureShop.ShopUI.Models
{
    public class ProductsModel
    {
        public int TotalOfProducts { get; set; }
        public IEnumerable<ProductModel> Products { get; set; } = new ProductModel[0];
    }
}
