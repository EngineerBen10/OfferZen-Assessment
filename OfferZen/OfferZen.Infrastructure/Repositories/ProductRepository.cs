using Microsoft.EntityFrameworkCore;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;
using OfferZen.Infrastructure.Data;

namespace OfferZen.Infrastructure.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    // Get products (with pagination + optional filtering)
    public async Task<PaginatedResult<ProductDto>> GetProductsAsync(ProductQueryDto productQueryDto, CancellationToken token)
    {
        var query = dbContext.Product
            .AsNoTracking()
            .Include(p => p.Category)
            .AsQueryable();

        // Optional filtering by category name
        if (!string.IsNullOrWhiteSpace(productQueryDto.CategoryName))
        {
            query = query.Where(p => p.Category.Name == productQueryDto.CategoryName);
        }

        // Optional search filter (name or description)
        if (!string.IsNullOrWhiteSpace(productQueryDto.Search))
        {
            var search = productQueryDto.Search.ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search));
        }

        var totalCount = await query.CountAsync(token);

        var products = await query
            .OrderBy(p => p.Name)
            .Skip((productQueryDto.PageNumber - 1) * productQueryDto.PageSize)
            .Take(productQueryDto.PageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Sku = p.Sku,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryName = p.Category.Name
            })
            .ToListAsync(token);

        return new PaginatedResult<ProductDto>(
            items: products,
            totalCount: totalCount,
            pageNumber: productQueryDto.PageNumber,
            pageSize: productQueryDto.PageSize
        );
    }


    //Get single product by ID
    public async Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken)
    {
        var product = await dbContext.Product
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product == null)
            throw new KeyNotFoundException($"Product with ID {productId} not found.");

        return product;
    }
    // 🔹 3. Add new product
    public async Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        // Ensure category exists
        bool categoryExists = await dbContext.Category.AnyAsync(c => c.Id == product.CategoryId, cancellationToken);
        if (!categoryExists)
            throw new InvalidOperationException($"Category with ID {product.CategoryId} does not exist.");

        // Ensure unique SKU
        bool skuExists = await dbContext.Product.AnyAsync(p => p.Sku == product.Sku, cancellationToken);
        if (skuExists)
            throw new InvalidOperationException($"Product with SKU {product.Sku} already exists.");

        await dbContext.Product.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return product;
    }

    // Update product
    public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        var existing = await dbContext.Product.FindAsync(new object[] { product.Id }, cancellationToken);

        if (existing == null)
            throw new KeyNotFoundException($"Product with ID {product.Id} not found.");

        existing.Name = product.Name;
        existing.Description = product.Description;
        existing.Price = product.Price;
        existing.CategoryId = product.CategoryId;

        dbContext.Product.Update(existing);
        await dbContext.SaveChangesAsync(cancellationToken);

        return existing;
    }


    // Delete product
    public async Task<bool> DeleteProductAsync(int productId, CancellationToken cancellationToken)
    {
        var existing = await dbContext.Product.FindAsync(new object[] { productId }, cancellationToken);

        if (existing == null)
            return false;

        dbContext.Product.Remove(existing);
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}

