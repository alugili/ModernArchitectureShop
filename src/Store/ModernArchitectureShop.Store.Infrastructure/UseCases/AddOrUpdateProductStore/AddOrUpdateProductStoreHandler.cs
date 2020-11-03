using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreHandler : IRequestHandler<AddOrdUpdateProductStoreCommand, AddOrUpdateProductStoreResponse>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IProductRepository _productRepository;

        public AddOrUpdateProductStoreHandler(IStoreRepository storeRepository, IProductRepository productRepository)
        {
            _storeRepository = storeRepository;
            _productRepository = productRepository;
        }

        public async Task<AddOrUpdateProductStoreResponse> Handle(AddOrdUpdateProductStoreCommand command, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetAsync(command.StoreId, cancellationToken);

            if (store == null)
            {
                throw new NullReferenceException($"The store with Id ({command.StoreId}) is not found!");
            }

            var product = await _productRepository.GetAsync(command.ProductId, cancellationToken);

            if (product == null)
            {
                throw new NotImplementedException($"Could not find the Product-({command.ProductId})");
            }

            var quantityAllStores = product.Quantity;

            // update Product todo!
            return new AddOrUpdateProductStoreResponse
            {
                ProductId = product.ProductId,
                StoreId = store.StoreId,
                Code = product.Code,
                StoreName = store.Name,
                Quantity = quantityAllStores,
                CanPurchase = quantityAllStores > 0
            };
        }

    }
}
