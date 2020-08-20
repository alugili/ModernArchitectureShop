using MediatR;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.GetProducts
{
    public class GetItemsCommand : IRequest<GetItemsCommandResponse>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Username { get; set; }
    }
}
