using System;
using FluentValidation;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.AddOrUpdateProductStore
{
    public class AddOrUpdateProductStoreValidator : AbstractValidator<AddOrdUpdateProductStoreCommand>
    {
        public AddOrUpdateProductStoreValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEqual(Guid.Empty);

            RuleFor(x => x.StoreId)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEqual(Guid.Empty);
        }
    }
}
