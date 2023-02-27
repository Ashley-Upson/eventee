using Eventee.Discord.Brokers.Eventee;
using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities.Contexts;
using Eventee.Entities.Contexts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ProfileAPI.Brokers.DateTime;

namespace Eventee;

public static class IServiceCollectionExtensions
{
    public static void AddEventee(this IServiceCollection services)
    {
        AddEventeeBrokers(services);
        AddEventeeServices(services);
        AddEventeeProcessing(services);
    }

    private static void AddEventeeBrokers(IServiceCollection services)
    {
        services.AddDbContext<EventeeDbContext>();
        services.AddTransient<IEventeeDbContextFactory, IEventeeDbContextFactory>();

        services.AddTransient<IServerBroker, ServerBroker>();
        services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        services.AddTransient<IServerService, ServerService>();
    }

    private static void AddEventeeServices(IServiceCollection services)
    {

    }

    private static void AddEventeeProcessing(IServiceCollection services)
    {

    }
}