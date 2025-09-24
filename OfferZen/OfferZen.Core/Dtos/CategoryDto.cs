namespace OfferZen.Core.Dtos;

public record CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    
    public int? ParentCategoryId { get; init; }

    public List<CategoryDto> SubCategories { get; set; } = new();
}