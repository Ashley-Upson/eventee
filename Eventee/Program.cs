using System.Runtime.CompilerServices;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord;
using Eventee.Discord.Services.Orchestration;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing;
using Eventee.Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eventee;

static class Program
{
    private static IDiscordOrchestrationService discordService;

    static void Main(string[] args)
    {
        Console.WriteLine("Initialising app and building host...");

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var host = new HostBuilder()
            .ConfigureServices((_, services) => ConfigureServices(services, config))
            .Build();

        Program.discordService = host.Services.GetRequiredService<IDiscordOrchestrationService>();

        Console.WriteLine("Connecting to discord...");

        host.Run();
    }

    static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        Console.WriteLine("Configuring Services...");

        services.AddDbContext<EventeeDbContext>();

        services.AddEventee(config.GetValue<string>("DiscordToken"));

        services.AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged,
            LogGatewayIntentWarnings = false,
            AlwaysDownloadUsers = true,
            LogLevel = LogSeverity.Debug
        }));

        // Used for slash commands and their registration with Discord.
        services.AddSingleton(serviceProvider => new InteractionService(serviceProvider.GetRequiredService<DiscordSocketClient>()));

        // Required to subscribe to the various client events used in conjunction with Interactions.
        services.AddSingleton<InteractionHandler>();

        services.AddSingleton(x => new CommandService(new CommandServiceConfig
        {
            LogLevel = LogSeverity.Debug,
            DefaultRunMode = global::Discord.Commands.RunMode.Async
        }));
    }
}