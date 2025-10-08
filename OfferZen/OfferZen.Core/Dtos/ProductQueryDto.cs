namespace OfferZen.Core.Dtos;

public class ProductQueryDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
    public string? CategoryName { get; set; } 
    public string? ProductName { get; set; }
    public string? Search { get; set; }
}