using System.Collections.Generic;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ProductsModel
    {
        public int TotalOfProducts { get; set; }
        public ICollection<ProductModel> Products { get; set; } = new ProductModel[0];
    }
}
