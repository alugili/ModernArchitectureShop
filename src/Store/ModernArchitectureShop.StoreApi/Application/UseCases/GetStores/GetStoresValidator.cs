using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.GetStores
{
    public class GetStoresValidator : AbstractValidator<GetStoresCommand>
    {
        public GetStoresValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);

            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
