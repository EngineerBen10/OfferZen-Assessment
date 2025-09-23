namespace OfferZen.Core.Entities;

public class Product
{
     public int Id { get; set; }
     public string Name { get; set; } = null!;
     public string Description { get; set; } = null!;
     public Guid Sku { get; set; } = Guid.NewGuid();
     public decimal Price { get; set; }
     public int Quantity { get; set; }
     
     public int CategoryId { get; set; }
    
     public DateTime CreatedAt { get; set; } 
     public Category Category { get; set; } = null!;

}