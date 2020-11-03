using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateStore
{
    public class CreateStoreValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
