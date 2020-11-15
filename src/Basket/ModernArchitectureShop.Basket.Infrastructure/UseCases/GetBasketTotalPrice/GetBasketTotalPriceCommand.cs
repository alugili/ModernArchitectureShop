using MediatR;
using ModernArchitectureShop.Basket.Application.UseCases.GetBasketTotalPrice;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetBasketTotalPrice
{
    public class GetBasketTotalPriceCommand : IRequest<GetBasketTotalPriceResponse>, IBasketTotalPrice
    {
        public string Username { get; set; } = string.Empty;
    }
}
