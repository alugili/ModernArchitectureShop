using System;
using MediatR;
using Dapr.Client;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.Basket.Application.Persistence;
using ModernArchitectureShop.Basket.Infrastructure.Dapr.Publishers;
using ModernArchitectureShop.Basket.Infrastructure.Dto;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.AddItem
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, ItemDto>
    {
        private readonly DaprClient _daprClient;
        private readonly IItemRepository _itemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly BasketItemNotificationHandler _basketItemNotificationHandler;
        private readonly IMapper _mapper;

        public AddItemHandler(
                              DaprClient daprClient,
                              IItemRepository itemRepository,
                              IBasketRepository basketRepository,
                              IMapper mapper,
                              BasketItemNotificationHandler basketItemNotificationHandler)
        {
            _daprClient = daprClient;
            _itemRepository = itemRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
            _basketItemNotificationHandler = basketItemNotificationHandler;
        }

        public async Task<ItemDto> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            var itemFromCommand = _mapper.Map<Item>(command);

            // Just for demo to show that Dapr Store working!
            //var oldItem = await _daprClient.GetStateAsync<Item>("default", itemFromCommand.ItemId.ToString(), cancellationToken: cancellationToken);

            var basket = await _basketRepository.GetBasketSingeOrDefault(command.Username, cancellationToken);
            var isBasketNotExits = (basket == null);

            if (isBasketNotExits)
            {
                basket = new Domain.Basket { BasketId = Guid.NewGuid(), Username = command.Username, State = State.Unlocked };
                await _basketRepository.AddAsync(basket, cancellationToken);
                await _basketRepository.SaveChangesAsync(cancellationToken);
            }

            var itemFromDb = await _itemRepository.GetSingleOrDefault(itemFromCommand.ItemId, cancellationToken);

            itemFromCommand.BasketId = basket.BasketId;
            itemFromCommand.Basket = basket;

            if (itemFromDb == null)
            {
                await _itemRepository.AddAsync(itemFromCommand, cancellationToken);
                await _itemRepository.SaveChangesAsync(cancellationToken);
            }

            //await _basketItemNotificationHandler.Handle(new ItemCreatedMessage(), cancellationToken);

            //// Lock
            //await _daprClient.SaveStateAsync(
            //    "default",
            //    State.Locked.ToString(), ConsistencyMode.Strong,new StateOptions(),
            //    cancellationToken: cancellationToken);

            return _mapper.Map<ItemDto>(itemFromCommand);
        }
    }
}
