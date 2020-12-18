using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapr.Client;
using MediatR;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.AddOrder
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly DaprClient _daprClient;
        private readonly IOrderRepository _orderRepository;


        public PlaceOrderHandler(DaprClient daprClient, IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _daprClient = daprClient;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            var isOrderExits = await _orderRepository.GetProcessingAsync(command.Username, cancellationToken) != null;

            if (isOrderExits)
            {
                throw new InvalidOperationException("your order still im process.");
            }

            var orderFromCommand = _mapper.Map<Domain.Order>(command);

            orderFromCommand.State = State.Processing;

            await _orderRepository.AddAsync(orderFromCommand, cancellationToken);
            var numberOfWrittenData = await _orderRepository.SaveChangesAsync(cancellationToken);

            //await _daprClient.PublishEventAsync("default", "OrderPlacedEvent", order, cancellationToken);

            return (numberOfWrittenData > 0);
        }
    }
}
