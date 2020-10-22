using System;
using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.DeleteItem
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.ItemId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
