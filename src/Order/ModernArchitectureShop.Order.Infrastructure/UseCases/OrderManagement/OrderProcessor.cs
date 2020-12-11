using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapr.Client;
using ModernArchitectureShop.Order.Domain;
using ModernArchitectureShop.Order.Application.UseCases.OrderManagement;
using ModernArchitectureShop.Order.Infrastructure.Persistence;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IMapper _mapper;
        private readonly DaprClient _daprClient;
        private readonly OrderRepository _orderRepository;

        public OrderProcessor(DaprClient daprClient, OrderRepository orderRepository, IMapper mapper )
        {
            _mapper = mapper;
            _daprClient = daprClient;
            _orderRepository = orderRepository;
        }

        public Task<Domain.Order> GetOrderAsync(string username, Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ProcessOrderAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<int> PlaceOrderAsync(Domain.Order order, CancellationToken cancellationToken)
        {
            var isOrderExits = await _orderRepository.GetAsync(order.Username, order.OrderId, cancellationToken) != null;

            if (isOrderExits)
            {
                throw new InvalidOperationException($"your order still im process:  {order.OrderId}");
            }

            order.State = State.Received;

            await _orderRepository.AddAsync(order, cancellationToken);
            var saveCount = await _orderRepository.SaveChangesAsync(cancellationToken);

            //await _daprClient.PublishEventAsync("default", "OrderPlacedEvent", order, cancellationToken);

            return saveCount;


        }

        public Task SetStatusAsync(Domain.Order order, State state)
        {
            throw new NotImplementedException();
        }

        public Task EmailNotifyAsync(Domain.Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveReportAsync(Domain.Order order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
