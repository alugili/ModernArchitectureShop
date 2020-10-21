using FluentValidation;
using ModernArchitectureShop.Basket.Application.UseCases.AddItem;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.AddItem
{
    public class AddItemValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemValidator()
        {
            RuleFor(request => request.ItemId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.StoreId)
                .Cascade(CascadeMode.Stop)
                .NotNull();
            //.NotEmpty();Todo
        }
    }
}
