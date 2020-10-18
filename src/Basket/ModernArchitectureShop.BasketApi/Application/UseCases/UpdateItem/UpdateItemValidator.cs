using FluentValidation;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.UpdateItem
{
    public class UpdateItemValidator : AbstractValidator<UpdateItemCommand>
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
