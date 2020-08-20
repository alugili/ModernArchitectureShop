using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers;
using ModernArchitectureShop.BasketApi.Infrastructure.Dapr.Publishers.Messages;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly BasketDbContext _dbContext;
        private readonly ItemCreatedNotificationHandler _itemCreatedNotificationHandler;

        public DeleteItemHandler(BasketDbContext dbContext, ItemCreatedNotificationHandler itemCreatedNotificationHandler)
        {
            _dbContext = dbContext;
            _itemCreatedNotificationHandler = itemCreatedNotificationHandler;
        }

        public async Task<bool> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
        {
            var items = _dbContext.Set<Item>();
            var itemFromDb = await items.SingleAsync(x => x.ItemId == command.ItemId, cancellationToken: cancellationToken);

            _dbContext.Items.Remove(itemFromDb);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            await _itemCreatedNotificationHandler.Handle(new ItemDeletedMessage
            {
                ItemId = command.ItemId
            },
                cancellationToken);

            return result > 0;
        }
    }
}
