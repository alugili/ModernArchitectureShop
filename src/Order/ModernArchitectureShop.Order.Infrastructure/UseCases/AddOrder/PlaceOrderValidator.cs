using FluentValidation;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.AddOrder
{
    public class AddItemValidator : AbstractValidator<PlaceOrderCommand>
    {
        public AddItemValidator()
        {
            //RuleFor(request => request.Items)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull()
            //    .NotEmpty();

            RuleFor(request => request.Username)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
