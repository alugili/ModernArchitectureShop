using System;

namespace ModernArchitectureShop.Store.Domain
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public bool IsMainAddress { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
    }
}
