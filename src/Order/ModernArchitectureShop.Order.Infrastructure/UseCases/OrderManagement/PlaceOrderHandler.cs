using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapr.Client;
using MediatR;
using ModernArchitectureShop.Order.Domain;
using ModernArchitectureShop.Order.Infrastructure.Persistence;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly DaprClient _daprClient;
        private readonly OrderRepository _orderRepository;


        public PlaceOrderHandler(DaprClient daprClient, OrderRepository orderRepository, IMapper mapper )
        {
            _mapper = mapper;
            _daprClient = daprClient;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            var isOrderExits = await _orderRepository.GetAsync(command.Username, command.OrderId, cancellationToken) != null;

            if (isOrderExits)
            {
                throw new InvalidOperationException($"your order still im process:  {command.OrderId}");
            }

            var orderFromCommand = _mapper.Map<Domain.Order>(command);

            orderFromCommand.State = State.Received;

            await _orderRepository.AddAsync(orderFromCommand, cancellationToken);
            var numberOfWrittenData = await _orderRepository.SaveChangesAsync(cancellationToken);

            //await _daprClient.PublishEventAsync("default", "OrderPlacedEvent", order, cancellationToken);

            return (numberOfWrittenData > 0);
        }
    }
}
