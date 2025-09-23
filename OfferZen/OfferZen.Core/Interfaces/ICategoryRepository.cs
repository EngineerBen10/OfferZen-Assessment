using OfferZen.Core.Entities;

namespace OfferZen.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<IEnumerable<Category>> GetCategoriesTreeAsync();
    Task<Category> AddCategoryAsync(Category category);
}