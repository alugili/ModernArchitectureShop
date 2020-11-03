using System;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
