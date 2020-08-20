using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModernArchitectureShop.Basket.Domain;
using ModernArchitectureShop.BasketApi.Infrastructure.Dto;
using ModernArchitectureShop.BasketApi.Infrastructure.Persistence;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.UpdateItem
{
    public class UpdateProductHandler : IRequestHandler<UpdateItemCommand, ItemDto>
    {
        private readonly BasketDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductHandler(BasketDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
        {
            var productDbSet = _dbContext.Set<Item>();
            var product = await productDbSet.SingleOrDefaultAsync(x => x.ItemId == command.ProductId, cancellationToken: cancellationToken);

            if (product == null)
            {
                throw new NotImplementedException(command.ProductId.ToString());
            }

            product.Name = command.NewProductName;

            var entity = productDbSet.Update(product);

            return _mapper.Map<ItemDto>(entity.Entity);
        }

    }
}
