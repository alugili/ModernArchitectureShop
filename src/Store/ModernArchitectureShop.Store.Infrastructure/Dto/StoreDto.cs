using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public AddressDto? Address { get; set; }
        public IEnumerable<ProductDto> Products { get; set; } = new Collection<ProductDto>();
    }
}
