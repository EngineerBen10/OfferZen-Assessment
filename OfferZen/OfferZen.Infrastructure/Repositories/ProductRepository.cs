using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;
using OfferZen.Infrastructure.Data;

namespace OfferZen.Infrastructure.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public Task<PaginatedResult<ProductDto>> GetProductsAsync(ProductQueryDto productQueryDto, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(int productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}