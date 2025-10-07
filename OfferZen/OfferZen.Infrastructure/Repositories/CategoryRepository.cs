using Microsoft.EntityFrameworkCore;
using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;
using OfferZen.Core.Interfaces;
using OfferZen.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferZen.Infrastructure.Repositories
{
    internal class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
    {
        public async Task<Category> AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
             if(category == null) throw new ArgumentNullException(nameof(category));

              if(category.ParentCategoryId.HasValue)
            {
                var parentCategory = await dbContext.Category
                    .FirstOrDefaultAsync(c => c.Id == category.ParentCategoryId.Value, cancellationToken);
                if (parentCategory == null)
                {
                    throw new ArgumentException($"Parent category with ID {category.ParentCategoryId.Value} does not exist.");
                }
            }

            await dbContext.Category.AddAsync(category, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Category
                     .AsNoTracking()
                     .Select(c => new Category
                     {
                         Id = c.Id,
                         Name = c.Name,
                         Description = c.Description,
                         ParentCategoryId = c.ParentCategoryId
                     })
                     .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesTreeAsync(CancellationToken cancellationToken)
        {
            var categories = await dbContext.Category
                .AsNoTracking()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ParentCategoryId = c.ParentCategoryId
                }).ToListAsync(cancellationToken);

               // child access
            var categoryLookup = categories.ToLookup(c => c.ParentCategoryId);

            List<CategoryDto> CategoryTree(int? parentId)
            {

                return categoryLookup[parentId]
                    .Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        ParentCategoryId = c.ParentCategoryId,
                        SubCategories = CategoryTree(c.Id)
                    })
                    .ToList();
            }

            var tree = CategoryTree(null);

            return tree;
        }
    }
}
