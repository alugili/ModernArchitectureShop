
using System;

namespace ModernArchitectureShop.Store.Application.UseCases.CreateStore
{
    public interface ICreateStore
    {
        public string Name { get; }
        public Guid AddressId { get; }
    }
}
