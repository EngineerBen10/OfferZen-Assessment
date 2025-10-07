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
        public Task<Category> AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetCategoriesTreeAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
