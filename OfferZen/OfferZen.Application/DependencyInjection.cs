using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace OfferZen.Application;

public  static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(mcfg =>
        {
              mcfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
              mcfg.NotificationPublisher = new TaskWhenAllPublisher();
              
        });
        
        return services;
    }
}