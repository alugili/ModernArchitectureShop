using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.AddItem
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, ItemDto>
    {
        private readonly BasketDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ItemCreatedNotificationHandler _itemCreatedNotificationHandler;

        public AddItemHandler(BasketDbContext dbContext, IMapper mapper, ItemCreatedNotificationHandler itemCreatedNotificationHandler)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _itemCreatedNotificationHandler = itemCreatedNotificationHandler;
        }

        public async Task<ItemDto> Handle(AddItemCommand command, CancellationToken cancellationToken)
        {
            var itemFromCommand = _mapper.Map<Item>(command);

            var items = _dbContext.Set<Item>();
            var itemFromDb = await items.SingleOrDefaultAsync(x => x.ItemId == command.ItemId, cancellationToken: cancellationToken);
            if (itemFromDb != null)
            {
                _mapper.Map(itemFromCommand, itemFromDb);
                items.Update(itemFromDb);
            }
            else
            {
                await _dbContext.Items.AddAsync(itemFromCommand, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            await _itemCreatedNotificationHandler.Handle(new ItemCreatedMessage(), cancellationToken);

            return _mapper.Map<ItemDto>(itemFromCommand);
        }
    }
}
