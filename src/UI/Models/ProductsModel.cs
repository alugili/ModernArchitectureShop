using System.Collections.ObjectModel;

namespace ModernArchitectureShop.BlazorUI.Models
{
    public class ProductsModel
    {
        public int TotalOfProducts { get; set; }
        public Collection<ProductModel> Products { get; set; } = new Collection<ProductModel>();
    }
}
