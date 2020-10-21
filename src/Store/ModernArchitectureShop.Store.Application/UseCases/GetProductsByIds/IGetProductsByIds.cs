using System;
using System.Collections.Generic;

namespace ModernArchitectureShop.Store.Application.UseCases.GetProductsByIds
{
    public interface IGetProductsByIds
    {
        public IEnumerable<Guid> ProductIds { get; set; } 
    }
}
