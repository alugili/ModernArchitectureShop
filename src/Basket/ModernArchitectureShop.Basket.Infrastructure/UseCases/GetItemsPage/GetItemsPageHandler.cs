using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItemsPage
{
    internal class GetItemsPageHandler : IRequestHandler<GetItemsPageCommand, GetItemsPageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public GetItemsPageHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetItemsPageResponse> Handle(GetItemsPageCommand command, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetPageAsync(command.Username, command.PageIndex, command.PageSize, cancellationToken);

            return new GetItemsPageResponse
            {
                Items = _mapper.Map<IEnumerable<ItemDto>>(items),
                TotalOfItems = await _itemRepository.TotalCountAsync(command.Username, cancellationToken)
            };
        }
    }
}
