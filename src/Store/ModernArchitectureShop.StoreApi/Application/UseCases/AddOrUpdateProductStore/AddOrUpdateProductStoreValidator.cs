using System;
using FluentValidation;

namespace ModernArchitectureShop.StoreApi.Application.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreValidator : AbstractValidator<AddOrdUpdateProductStoreCommand>
    {
        public AddOrUpdateProductStoreValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEqual(Guid.Empty);

            RuleFor(x => x.StoreId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEqual(Guid.Empty);
        }
    }
}
