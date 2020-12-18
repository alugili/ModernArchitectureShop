using FluentValidation;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetOrders
{
    public class GetOrdersValidator : AbstractValidator<GetOrdersCommand>
    {
        public GetOrdersValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
        }
    }
}
