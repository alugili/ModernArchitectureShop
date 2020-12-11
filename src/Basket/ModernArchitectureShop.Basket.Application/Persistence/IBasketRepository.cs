using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModernArchitectureShop.Basket.Application.Persistence
{
    public interface IBasketRepository : IDisposable
    {
        void CreateDatabase();

        void Remove(Domain.Basket basket);

        void Update(Domain.Basket basket);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        ValueTask<Domain.Basket?> GetBasketSingeOrDefault(string username, CancellationToken cancellationToken);

        ValueTask AddAsync(Domain.Basket basket, CancellationToken cancellationToken);

        ValueTask<Domain.Basket> GetAsync(string username,
                                          int pageIndex, int pageSize,
                                          CancellationToken cancellationToken);

        ValueTask<int> TotalCountAsync(string username, CancellationToken cancellationToken);

        ValueTask<double> TotalPriceAsync(string username, CancellationToken cancellationToken);
    }
}
