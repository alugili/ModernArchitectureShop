using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Store.Domain;
using ModernArchitectureShop.StoreApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreHandler : IRequestHandler<AddOrdUpdateProductStoreCommand, AddOrUpdateProductStoreResponse>
    {
        private readonly StoreDbContext _dbContext;

        public AddOrUpdateProductStoreHandler(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddOrUpdateProductStoreResponse> Handle(AddOrdUpdateProductStoreCommand command, CancellationToken cancellationToken)
        {
            var storeQuery = _dbContext.Set<Store.Domain.Store>();

            var store = await storeQuery.SingleOrDefaultAsync(x => x.StoreId == command.StoreId, cancellationToken);

            if (store == null)
            {
                throw new NotImplementedException($"Could not find ProductStores-{command.StoreId}.");
            }

            var product = await _dbContext.Set<Product>()
                .SingleOrDefaultAsync(x => x.ProductId == command.ProductId, cancellationToken);

            if (product == null)
            {
                throw new NotImplementedException($"Could not find Products-{command.ProductId}");
            }

            var productStore = store.ProductStores.SingleOrDefault(x => x.Product == product);

            if (productStore == null)
            {
                productStore = new ProductStore();
            }

            storeQuery.Update(store);

            return new AddOrUpdateProductStoreResponse
            {
                ProductId = product.ProductId,
                StoreId = store.StoreId,
                Code = product.Code,
                StoreName = store.Name,
                Quantity = productStore.Quantity,
                CanPurchase = productStore.CanPurchase
            };
        }

    }
}
