using System;
using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.DeleteProduct
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProduct>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEqual(Guid.Empty);

        }
    }
}
