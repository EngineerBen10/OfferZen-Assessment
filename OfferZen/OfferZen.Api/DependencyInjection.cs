using OfferZen.Application;
using OfferZen.Core;
using OfferZen.Infrastructure;


namespace OfferZen.Api;

public static  class DependencyInjection
{

    public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication()
            .AddInfrastructure()
            .AddCore(configuration);
        return services;
    }
}