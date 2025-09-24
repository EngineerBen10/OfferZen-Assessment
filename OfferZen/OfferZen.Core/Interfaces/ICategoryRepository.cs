using OfferZen.Core.Dtos;
using OfferZen.Core.Entities;

namespace OfferZen.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken);
    Task<IEnumerable<CategoryDto>> GetCategoriesTreeAsync(CancellationToken cancellationToken);
    Task<Category> AddCategoryAsync(Category category, CancellationToken cancellationToken);
}