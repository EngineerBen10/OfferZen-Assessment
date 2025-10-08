using System.Text.Json.Serialization;

namespace OfferZen.Core.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }   
    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }

    [JsonIgnore]
    public ICollection<Category>? SubCategories { get; set; } = new List<Category>();

    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}