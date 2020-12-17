using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems
{
    public class GetItemsValidator : AbstractValidator<GetItemsCommand>
    {
        public GetItemsValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
        }
    }
}
