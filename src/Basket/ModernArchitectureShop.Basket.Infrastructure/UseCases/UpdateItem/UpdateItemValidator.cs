using FluentValidation;

namespace ModernArchitectureShop.Basket.Infrastructure.UseCases.UpdateItem
{
    public class UpdateItemValidator : AbstractValidator<UpdateItem>
    {
        public UpdateItemValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotNull();

            RuleFor(x => x.NewProductName)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty();
        }
    }
}
