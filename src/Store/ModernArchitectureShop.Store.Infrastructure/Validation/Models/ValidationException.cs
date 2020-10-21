using System;

namespace ModernArchitectureShop.Store.Infrastructure.Validation.Models
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
