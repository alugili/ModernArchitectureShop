using MediatR;
using ModernArchitectureShop.Store.Application.UseCases.GetProducts;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProducts
{
    public class GetProductsCommand : IRequest<GetProductsResponse>, IGetProducts
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
