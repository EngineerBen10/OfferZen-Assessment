using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.ProductQueries;


 public record GetProductQuery(ProductQueryDto ProductQuery) : IRequest<PaginatedResult<ProductDto>>;

 public class GetProductQueryHandler(IProductRepository productRepository)
     : IRequestHandler<GetProductQuery, PaginatedResult<ProductDto>>
 {
     public async Task<PaginatedResult<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
     {
         return await productRepository.GetProductsAsync(request.ProductQuery, cancellationToken);
     }
 }