namespace OfferZen.Core.Dtos;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public Guid Sku { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public string CategoryName { get; init; } = null!;
}