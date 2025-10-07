using MediatR;
using OfferZen.Core.Dtos;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries;


 public record GetProductsSearchEngineQuery(ProductQueryDto ProductQuery) : IRequest<PaginatedResult<ProductDto>>;

 public class GetProductSearchEngineQuery(IProductSerchEngine productSearchEngine)
     : IRequestHandler<GetProductsSearchEngineQuery, PaginatedResult<ProductDto>>
 {
     public async Task<PaginatedResult<ProductDto>> Handle(GetProductsSearchEngineQuery request, CancellationToken cancellationToken)
     {
         return await productSearchEngine.ProductSearchEngineAsync(request.ProductQuery, cancellationToken);
     }
 }