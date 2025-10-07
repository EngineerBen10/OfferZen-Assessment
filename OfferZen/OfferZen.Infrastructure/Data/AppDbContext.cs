using Microsoft.EntityFrameworkCore;
using OfferZen.Core;
using OfferZen.Core.Entities;

namespace OfferZen.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
     public DbSet<Product> Product { get; set; }
     public DbSet<Category> Category { get; set; }
}