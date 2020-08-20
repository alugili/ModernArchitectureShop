using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProducts
{
    public class GetProductsValidator : AbstractValidator<GetProductsCommand>
    {
        public GetProductsValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
