using Microsoft.EntityFrameworkCore;
using OfferZen.Core.Dtos;
using OfferZen.Core.Interfaces;
using OfferZen.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferZen.Infrastructure.Repositories
{


    public class ProductSearchEngine(AppDbContext dbContext) : IProductSerchEngine
    {
        public async Task<PaginatedResult<ProductDto>> ProductSearchEngineAsync(ProductQueryDto productQueryDto, CancellationToken token)
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
    }
}
