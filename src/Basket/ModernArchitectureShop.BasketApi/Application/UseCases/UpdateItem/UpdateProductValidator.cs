using FluentValidation;

namespace ModernArchitectureShop.BasketApi.Application.UseCases.UpdateItem
{
    public class UpdateProductValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();

            RuleFor(x => x.NewProductName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty();
        }
    }
}
