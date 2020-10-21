using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapr.Client;
using MediatR;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.AddItem
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, ItemDto>
    {
        private readonly DaprClient _daprClient;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly BasketItemNotificationHandler _basketItemNotificationHandler;

        public AddItemHandler(DaprClient daprClient, IItemRepository itemRepository, IMapper mapper, BasketItemNotificationHandler basketItemNotificationHandler)
        {
            _daprClient = daprClient;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _basketItemNotificationHandler = basketItemNotificationHandler;
        }

        public async Task<ItemDto> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            var itemFromCommand = _mapper.Map<Item>(command);

            // Just for demo to show that Dapr Store working!
            //var oldItem = await _daprClient.GetStateAsync<Item>("default", itemFromCommand.ItemId.ToString(), cancellationToken: cancellationToken);

            var itemFromDb = await _itemRepository.GetAsync(itemFromCommand.ItemId, cancellationToken);

            if (itemFromDb != null)
            {
                _mapper.Map(itemFromCommand, itemFromDb);
                _itemRepository.Update(itemFromDb);
            }
            else
            {
                await _itemRepository.AddAsync(itemFromCommand, cancellationToken);
            }

            await _itemRepository.SaveChangesAsync(cancellationToken);
            //await _basketItemNotificationHandler.Handle(new BasketItemCreatedMessage(), cancellationToken);

            return _mapper.Map<ItemDto>(itemFromCommand);
        }
    }
}
