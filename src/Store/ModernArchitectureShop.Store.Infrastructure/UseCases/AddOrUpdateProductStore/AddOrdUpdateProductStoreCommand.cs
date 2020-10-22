using System;
using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.AddOrUpdateProductStore;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.AddOrUpdateProductStore
{
    public class AddOrdUpdateProductStoreCommand : IRequest<AddOrUpdateProductStoreResponse>, IAddOrdUpdateProductStore
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
