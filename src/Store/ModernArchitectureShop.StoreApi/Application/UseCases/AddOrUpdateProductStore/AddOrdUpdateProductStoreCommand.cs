using System;
using MediatR;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.AddOrUpdateProductStore
{
    public class AddOrdUpdateProductStoreCommand : IRequest<AddOrUpdateProductStoreResponse>
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public int Quantity { get; set; }
        public bool CanPurchase { get; set; }
    }
}
