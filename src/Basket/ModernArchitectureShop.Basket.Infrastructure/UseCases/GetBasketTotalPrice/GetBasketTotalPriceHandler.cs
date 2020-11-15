using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Basket.Application.Persistence;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetBasketTotalPrice
{
    internal class GetBasketTotalPriceHandler : IRequestHandler<GetBasketTotalPriceCommand, GetBasketTotalPriceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetBasketTotalPriceHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetBasketTotalPriceResponse> Handle(GetBasketTotalPriceCommand command, CancellationToken cancellationToken)
        {
            var totalPrice = await _itemRepository.TotalPriceAsync(command.Username, cancellationToken);

            return new GetBasketTotalPriceResponse
            {
                TotalPrice = totalPrice
            };
        }
    }
}
