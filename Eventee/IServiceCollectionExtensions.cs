using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord;
using Eventee.Discord.Brokers;
using Eventee.Discord.Brokers.Eventee;
using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Brokers.Interfaces;
using Eventee.Discord.Services.Foundation;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Orchestration;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities.Contexts;
using Eventee.Entities.Contexts.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventee;

public static class IServiceCollectionExtensions
{
    public static void AddEventee(this IServiceCollection services, string token)
    {
        services.AddDiscordBot();

        services.AddEventeeBrokers(token);
        services.AddEventeeServices();
        services.AddEventeeProcessing();
        services.AddEventeeOrchestration();
    }

    private static void AddDiscordBot(this IServiceCollection services)
    {
        services.AddSingleton<DiscordSocketClient>();

        services.AddSingleton<InteractionService>();

        services.AddSingleton<InteractionHandler>(serviceProvider =>
        {
            var client = serviceProvider.GetService<DiscordSocketClient>();
            var interactionService = serviceProvider.GetService<InteractionService>();
            var handler = new InteractionHandler(client, interactionService, serviceProvider);
            
            handler.InitializeAsync().RunSynchronously();

            return handler;
        });

        services.AddSingleton<DiscordBot>();
    }

    private static void AddEventeeBrokers(this IServiceCollection services, string token)
    {
        services.AddDbContext<EventeeDbContext>();
        services.AddTransient<IEventeeDbContextFactory, EventeeDbContextFactory>();

        services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        services.AddTransient<ILoggingBroker, LoggingBroker>();

        services.AddTransient<IServerBroker, ServerBroker>();
        services.AddTransient<IChannelBroker, ChannelBroker>();
        services.AddTransient<IRoleBroker, RoleBroker>();
        services.AddTransient<IEventBroker, EventBroker>();
        services.AddTransient<IMemberBroker, MemberBroker>();
        services.AddTransient<IReminderBroker, ReminderBroker>();
        services.AddTransient<IEventMemberBroker, EventMemberBroker>();
        services.AddTransient<IRSVPBroker, RSVPBroker>();

        services.AddTransient<IDiscordBroker, DiscordBroker>(serviceProvider =>
        {
            var bot = serviceProvider.GetService<DiscordBot>();
            
            bot.InitialiseDiscordBot(token);

            return new DiscordBroker(bot);
        });
    }

    private static void AddEventeeServices(this IServiceCollection services)
    {
        services.AddTransient<IServerService, ServerService>();
        services.AddTransient<IChannelService, ChannelService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IMemberService, MemberService>();
        services.AddTransient<IReminderService, ReminderService>();
        services.AddTransient<IEventMemberService, EventMemberService>();
        services.AddTransient<IRSVPService, RSVPService>();

        services.AddTransient<IDiscordService, DiscordService>();
    }

    private static void AddEventeeProcessing(this IServiceCollection services)
    {
        services.AddTransient<IServerProcessingService, ServerProcessingService>();
        services.AddTransient<IChannelProcessingService, ChannelProcessingService>();
        services.AddTransient<IRoleProcessingService, RoleProcessingService>();
        services.AddTransient<IEventProcessingService, EventProcessingService>();
        services.AddTransient<IMemberProcessingService, MemberProcessingService>();
        services.AddTransient<IReminderProcessingService, ReminderProcessingService>();
        services.AddTransient<IEventMemberProcessingService, EventMemberProcessingService>();
        services.AddTransient<IRSVPProcessingService, RSVPProcessingService>();

        services.AddTransient<IDiscordProcessingService, DiscordProcessingService>();
    }

    private static void AddEventeeOrchestration(this IServiceCollection services)
    {
        services.AddTransient<IServerOrchestrationService, ServerOrchestrationService>();
        services.AddTransient<IMemberOrchestrationService, MemberOrchestrationService>();
        services.AddTransient<IEventOrchestrationService, EventOrchestrationService>();
        services.AddTransient<IEventMemberOrchestrationService, EventMemberOrchestrationService>();

        services.AddTransient<IDiscordOrchestrationService, DiscordOrchestrationService>();
    }
}