using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItems
{
    public class GetItemsValidator : AbstractValidator<GetItemsCommand>
    {
        public GetItemsValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);
            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
