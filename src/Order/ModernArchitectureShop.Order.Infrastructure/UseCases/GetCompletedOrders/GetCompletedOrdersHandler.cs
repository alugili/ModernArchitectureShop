using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Order.Application.Persistence;
using ModernArchitectureShop.Order.Infrastructure.Dto;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetCompletedOrders
{
    public class GetCompletedOrdersHandler : IRequestHandler<GetCompletedOrdersCommand, GetCompletedOrdersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetCompletedOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetCompletedOrdersResponse> Handle(GetCompletedOrdersCommand command, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetCompletedAsync(command.Username, cancellationToken);

            return new GetCompletedOrdersResponse
            {
                Orders = _mapper.Map<IEnumerable<OrderDto>>(orders)
            };
        }
    }
}
