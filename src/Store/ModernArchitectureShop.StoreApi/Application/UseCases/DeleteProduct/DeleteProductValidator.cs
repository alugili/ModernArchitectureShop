using System;
using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.DeleteProduct
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductCommand>
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
