using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.UpdateItem
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, ItemDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(command);

            _itemRepository.Update(item);

            return _mapper.Map<ItemDto>(item);
        }

    }
}
