using Eventee.Discord.Brokers.Eventee;
using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Orchestration;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing;
using Eventee.Discord.Services.Processing.Interfaces;
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
        AddEventeeOrchestration(services);
    }

    private static void AddEventeeBrokers(IServiceCollection services)
    {
        services.AddDbContext<EventeeDbContext>();
        services.AddTransient<IEventeeDbContextFactory, EventeeDbContextFactory>();

        services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        services.AddTransient<IServerBroker, ServerBroker>();
        services.AddTransient<IChannelBroker, ChannelBroker>();
        services.AddTransient<IRoleBroker, RoleBroker>();
        services.AddTransient<IEventBroker, EventBroker>();
        services.AddTransient<IMemberBroker, MemberBroker>();
        services.AddTransient<IReminderBroker, ReminderBroker>();
        services.AddTransient<IEventMemberBroker, EventMemberBroker>();
        services.AddTransient<IRSVPBroker, RSVPBroker>();
    }

    private static void AddEventeeServices(IServiceCollection services)
    {
        services.AddTransient<IServerService, ServerService>();
        services.AddTransient<IChannelService, ChannelService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IMemberService, MemberService>();
        services.AddTransient<IReminderService, ReminderService>();
        services.AddTransient<IEventMemberService, EventMemberService>();
        services.AddTransient<IRSVPService, RSVPService>();
    }

    private static void AddEventeeProcessing(IServiceCollection services)
    {
        services.AddTransient<IServerProcessingService, ServerProcessingService>();
        services.AddTransient<IChannelProcessingService, ChannelProcessingService>();
        services.AddTransient<IRoleProcessingService, RoleProcessingService>();
        services.AddTransient<IEventProcessingService, EventProcessingService>();
        services.AddTransient<IMemberProcessingService, MemberProcessingService>();
        services.AddTransient<IReminderProcessingService, ReminderProcessingService>();
        services.AddTransient<IEventMemberProcessingService, EventMemberProcessingService>();
        services.AddTransient<IRSVPProcessingService, RSVPProcessingService>();
    }

    private static void AddEventeeOrchestration(IServiceCollection services)
    {
        services.AddTransient<IServerOrchestrationService, ServerOrchestrationService>();
        services.AddTransient<IMemberOrchestrationService, MemberOrchestrationService>();
        services.AddTransient<IEventOrchestrationService, EventOrchestrationService>();
        services.AddTransient<IEventMemberOrchestrationService, EventMemberOrchestrationService>();
    }
}