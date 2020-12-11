using FluentValidation;
using ModernArchitectureShop.Order.Domain;

namespace ModernArchitectureShop.Order.Infrastructure.UseCases.OrderManagement
{
    public class AddItemValidator : AbstractValidator<PlaceOrderCommand>
    {
        public AddItemValidator()
        {
            RuleFor(request => request.OrderId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(request => request.Username)
                .Cascade(CascadeMode.Stop)
                .NotNull();

            RuleFor(request => request.State)
                .Cascade(CascadeMode.Stop)
                .Equal(State.Received);
        }
    }
}
