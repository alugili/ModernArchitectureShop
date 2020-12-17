using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.GetItemsPage
{
    public class GetItemsPageValidator : AbstractValidator<GetItemsPageCommand>
    {
        public GetItemsPageValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);
            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
