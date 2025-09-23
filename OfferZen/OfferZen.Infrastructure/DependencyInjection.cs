
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OfferZen.Infrastructure.Data;
using OfferZen.Core.Interfaces;
using OfferZen.Core.Options;
using OfferZen.Infrastructure.Repositories;

namespace OfferZen.Infrastructure;

public static class DependencyInjection
{
     public static IServiceCollection AddInfrastructure(this IServiceCollection services)
     {

          services.AddDbContext<AppDbContext>((provider, options) =>
          {
               options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value
                    .DefaultConnection);
          });

          services.AddScoped<IProductRepository, ProductRepository>();
          
          return services;
     }
}