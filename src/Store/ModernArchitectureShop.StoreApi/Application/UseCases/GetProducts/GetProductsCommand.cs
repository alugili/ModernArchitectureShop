using MediatR;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProducts
{
    public class GetProductsCommand : IRequest<GetProductsCommandResponse>
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
