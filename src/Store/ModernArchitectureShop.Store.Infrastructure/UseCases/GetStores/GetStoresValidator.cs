using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetStores
{
    public class GetStoresValidator : AbstractValidator<GetStoreCommand>
    {
        public GetStoresValidator()
        {
        }
    }
}
