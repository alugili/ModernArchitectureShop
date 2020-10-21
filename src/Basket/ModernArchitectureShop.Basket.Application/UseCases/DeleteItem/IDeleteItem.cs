using System;

namespace ModernArchitectureShop.Basket.Application.UseCases.DeleteItem
{
    public interface IDeleteItem
    {
        public Guid ItemId { get; set; }
    }
}
