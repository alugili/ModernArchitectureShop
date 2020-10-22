using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.SearchProducts
{
    public class SearchProductsValidator : AbstractValidator<SearchProductsCommand>
    {
        public SearchProductsValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
