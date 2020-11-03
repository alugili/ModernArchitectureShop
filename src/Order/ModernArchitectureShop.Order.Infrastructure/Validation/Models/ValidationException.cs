using System;

namespace ModernArchitectureShop.Order.Infrastructure.Validation.Models
{
    public class ValidationException : Exception
    {
        public ValidationResultModel ValidationResultModel { get; }
        
        public ValidationException(ValidationResultModel validationResultModel)
        {
            ValidationResultModel = validationResultModel;
        }
    }
}
