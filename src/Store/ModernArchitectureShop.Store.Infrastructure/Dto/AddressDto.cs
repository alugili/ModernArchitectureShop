using System;

namespace ModernArchitectureShop.Store.Infrastructure.Dto
{
    public class AddressDto
    {
        public AddressDto(Guid addressId, string streetAddress, string city, string state, string zipCode)
        {
            AddressId = addressId;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Guid AddressId { get; }
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
    }
}
