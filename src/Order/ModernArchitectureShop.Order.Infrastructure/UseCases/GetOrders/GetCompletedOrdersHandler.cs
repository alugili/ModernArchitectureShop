using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Infrastructure.Dto;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetOrders
{
    internal class GetCompletedOrdersHandler : IRequestHandler<GetOrdersCommand, GetOrdersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetCompletedOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersCommand command, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetCompletedAsync(command.Username, cancellationToken);

            return new GetOrdersResponse
            {
                Orders = _mapper.Map<IEnumerable<OrderDto>>(orders)
            };
        }
    }
}
