using System;
using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
