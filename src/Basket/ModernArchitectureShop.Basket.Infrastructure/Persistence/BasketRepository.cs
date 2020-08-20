using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.Basket.Infrastructure.Persistence
{
    //Todo move the database stuff here!
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public async ValueTask<ICollection<Item>> GetProductsAsync()
        {
            return await _basketDbContext.Items.ToListAsync();
        }

        public async ValueTask<int> TotalCountAsync()
        {
            return await _basketDbContext.Items.CountAsync();
        }
    }
}
