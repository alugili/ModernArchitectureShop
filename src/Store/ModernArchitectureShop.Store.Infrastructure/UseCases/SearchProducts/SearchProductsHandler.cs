using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.SearchProducts
{
    public class SearchProductsHandler : IRequestHandler<SearchProductsCommand, SearchProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SearchProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<SearchProductsResponse> Handle(SearchProductsCommand command, CancellationToken cancellationToken)
        {
            var totalOfProducts = await _productRepository.SearchProductsCountAsync(command.Filter);

            var products =
                        await _productRepository
                                .SearchProductsQuery(command.Filter, command.PageIndex, command.PageSize)
                                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);


            var result = new SearchProductsResponse
            {
                Products = products,
                TotalOfProducts = totalOfProducts
            };

            return result;
        }
    }
}
