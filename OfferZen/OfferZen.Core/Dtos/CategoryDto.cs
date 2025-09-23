namespace OfferZen.Core.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public int? ParentCategoryId { get; set; }

    public List<CategoryDto> SubCategories { get; set; } = new();
}