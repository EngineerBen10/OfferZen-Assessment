using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.ProductQueries;


 public record GetProductsQuery(ProductQueryDto ProductQuery) : IRequest<PaginatedResult<ProductDto>>;

 public class GetProductQueryHandler(IProductRepository productRepository)
     : IRequestHandler<GetProductsQuery, PaginatedResult<ProductDto>>
 {
     public async Task<PaginatedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
     {
         return await productRepository.GetProductsAsync(request.ProductQuery, cancellationToken);
     }
 }