using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Core.Interfaces;

public interface IProductRepository
{
    Task<PaginatedResult<ProductDto>> GetProductsAsync(ProductQueryDto productQueryDto, CancellationToken token);
    Task<Product> GetProductAsync(int productId,CancellationToken cancellationToken);
    Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken);
    Task<Product> UpdateProductAsync(Product product,CancellationToken cancellationToken);
    Task<bool> DeleteProductAsync(int productId,CancellationToken cancellationToken);
}