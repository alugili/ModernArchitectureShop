using FluentValidation;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
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
