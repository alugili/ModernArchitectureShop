using System;
using FluentValidation;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.DeleteItem
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.ItemId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
