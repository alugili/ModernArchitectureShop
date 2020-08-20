using FluentValidation;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.AddItem
{
    public class AddItemValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemValidator()
        {
            RuleFor(request => request.ItemId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.StoreId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();
            //.NotEmpty();Todo
        }
    }
}
