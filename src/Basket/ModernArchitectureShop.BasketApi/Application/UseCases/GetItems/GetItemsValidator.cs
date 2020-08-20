using FluentValidation;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.GetProducts
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
