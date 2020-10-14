using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.CreateStore
{
    public class CreateStoreValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Location)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
