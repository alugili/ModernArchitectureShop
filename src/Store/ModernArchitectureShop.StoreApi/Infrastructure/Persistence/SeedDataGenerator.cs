using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.StoreApi.Infrastructure.Persistence
{
    public sealed class
        SeedDataGenerator
    {
        internal static (ICollection<Product>, ICollection<Store.Domain.Store>, ICollection<ProductStore>) GenerateSeed()
        {
            var products = new Collection<Product>();
            var stores = new Collection<Store.Domain.Store>();
            var productStores = new Collection<ProductStore>();

            for (var i = 10; i < 100; i++)
            {
                products.Add(
                    new Product
                    {
                        ProductId = new Guid($"12345678-1234-1234-1234-1234567891{i}"),
                        Code = $"11{i}",
                        Name = $"Products-{i}",
                        Price = 3.14 * i,
                        ImageUrl = "http://icons.iconarchive.com/icons/graphicloads/colorful-long-shadow/48/Basket-icon.png"
                    });

                stores.Add(
                    new Store.Domain.Store
                    {
                        StoreId = Guid.NewGuid(),
                        Name = $"Store{i}",
                        Location = "Birkenfeld",
                    });

                productStores.Add(
                    new ProductStore
                    {
                        CanPurchase = true,
                        StoreId = stores[Math.Abs(i - 10)].StoreId,
                        ProductId = products[Math.Abs(i - 10)].ProductId,
                        Quantity = 10
                    });
            }

            return (products, stores, productStores);
        }
    }
}
