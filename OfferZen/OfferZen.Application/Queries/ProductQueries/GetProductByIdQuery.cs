using MediatR;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;

namespace OfferZen.Application.Queries.ProductQueries;

public record GetProductByIdQuery(int ProductId) : IRequest<Product>;
public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
      public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
      {
            return await productRepository.GetProductAsync(request.ProductId, cancellationToken);
      }
}