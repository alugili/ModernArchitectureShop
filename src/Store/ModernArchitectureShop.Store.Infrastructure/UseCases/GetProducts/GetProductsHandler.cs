using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ModernArchitectureShop.Store.Application.Persistence;
using ModernArchitectureShop.Store.Infrastructure.Dto;
using ModernArchitectureShop.Store.Infrastructure.Persistence;

namespace ModernArchitectureShop.Store.Infrastructure.UseCases.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, GetProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductsResponse> Handle(GetProductsCommand command, CancellationToken cancellationToken)
        {
            var totalOfProducts = await _productRepository.CountAsync(cancellationToken);

            var products = await _productRepository.
                GetProductsQuery(command.PageIndex, command.PageSize)
                                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);

            var result = new GetProductsResponse
            {
                Products = products,
                TotalOfProducts = totalOfProducts
            };

            return result;
        }
    }
}
