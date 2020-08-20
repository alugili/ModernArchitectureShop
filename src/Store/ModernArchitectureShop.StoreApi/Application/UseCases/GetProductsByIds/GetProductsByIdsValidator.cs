using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetProductsByIds
{
    public class GetProductsByIdsValidator : AbstractValidator<GetProductsByIdsCommand>
    {
        public GetProductsByIdsValidator()
        {
            RuleFor(x => x.ProductIds)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();
        }
    }
}
