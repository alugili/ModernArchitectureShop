using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;

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
                           .SearchProductsAsync(
                                                command.Filter,
                                                command.PageIndex,
                                                command.PageSize,
                                                cancellationToken);

            var result = new SearchProductsResponse
            {
                Products = _mapper.Map<IEnumerable<ProductDto>>(products),
                TotalOfProducts = totalOfProducts
            };

            return result;
        }
    }
}
