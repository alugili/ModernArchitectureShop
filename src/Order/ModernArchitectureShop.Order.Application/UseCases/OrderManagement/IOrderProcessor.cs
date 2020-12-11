using System;
using System.Threading;
using System.Threading.Tasks;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Application.UseCases.OrderManagement
{
    public interface IOrderProcessor
    {
        public Task<ModernArchitectureShop.Order.Domain.Order> GetOrderAsync(string username, Guid id, CancellationToken cancellationToken);
        public Task ProcessOrderAsync(Guid id, CancellationToken cancellationToken);
        public ValueTask<int> PlaceOrderAsync(Domain.Order order, CancellationToken cancellationToken);
        public Task SetStatusAsync(Domain.Order order, State state);
        public Task EmailNotifyAsync(Domain.Order order, CancellationToken cancellationToken);
        public Task SaveReportAsync(Domain.Order order, CancellationToken cancellationToken);
    }
}
