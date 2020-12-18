using FluentValidation;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.GetCompletedOrders
{
    public class GetCompletedOrdersValidator : AbstractValidator<GetCompletedOrdersCommand>
    {
        public GetCompletedOrdersValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
        }
    }
}
