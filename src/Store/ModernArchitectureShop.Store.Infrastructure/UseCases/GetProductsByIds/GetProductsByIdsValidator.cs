using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProductsByIds
{
    public class GetProductsByIdsValidator : AbstractValidator<GetProductsByIds>
    {
        public GetProductsByIdsValidator()
        {
            RuleFor(x => x.ProductIds)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
