using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems
{
    internal class GetItemsHandler : IRequestHandler<GetItemsCommand, GetItemsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemsHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetItemsResponse> Handle(GetItemsCommand command, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAsync(command.Username, command.PageIndex, command.PageSize, cancellationToken);

            return new GetItemsResponse
            {
                Items = _mapper.Map<List<ItemDto>>(items),
                TotalOfItems = await _itemRepository.TotalCountAsync(command.Username, cancellationToken)
            };
        }
    }
}
