using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetBasketTotalPrice
{
    public class GetBasketTotalPriceValidator : AbstractValidator<GetBasketTotalPriceCommand>
    {
        public GetBasketTotalPriceValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().NotNull();
        }
    }
}
