using System.Collections.Generic;
using System.Threading.Tasks;
using ModernArchitectureShop.Basket.Domain;

namespace ModernArchitectureShop.BasketApi.Application.Persistence
{
    // Todo
    public interface IBasketRepository
    {
        ValueTask<ICollection<Item>> GetProductsAsync();

        ValueTask<int> TotalCountAsync();
    }
}
