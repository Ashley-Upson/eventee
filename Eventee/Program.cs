using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord;
using Eventee.Entities.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Eventee;

public class Program
{
    private readonly IConfiguration config;

    public Program(IConfiguration configuration)
    {
        this.config = configuration;
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Initialising app and building host...");

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .Build();

        var host = new HostBuilder()
            .ConfigureServices((_, services) => ConfigureServices(services, config))
            .ConfigureAppConfiguration((configure) =>
            {
                configure.AddJsonFile("appsettings.json", optional: false);
                configure.AddEnvironmentVariables();
            })
            .Build();


        Console.WriteLine("Connecting to discord");

        await InitialiseDiscordBot(host);

        host.Run();
    }

    static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        Console.WriteLine("Configuring Services");

        services.AddSingleton(config);

        services.AddDbContext<EventeeDbContext>();
        
        services.AddEventee();

        services.AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged,
            LogGatewayIntentWarnings = false,
            AlwaysDownloadUsers = true,
            LogLevel = LogSeverity.Debug
        }));

        // Used for slash commands and their registration with Discord.
        services.AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()));

        // Required to subscribe to the various client events used in conjunction with Interactions.
        services.AddSingleton<InteractionHandler>();

        services.AddSingleton(x => new CommandService(new CommandServiceConfig
        {
            LogLevel = LogSeverity.Debug,
            DefaultRunMode = global::Discord.Commands.RunMode.Async
        }));
    }

    static async Task InitialiseDiscordBot(IHost host)
    {
        IServiceProvider provider = host.Services;

        var commands = provider.GetRequiredService<InteractionService>();
        var client = provider.GetRequiredService<DiscordSocketClient>();

        await provider.GetRequiredService<InteractionHandler>().InitializeAsync();
        // var client = new DiscordSocketClient();

        client.Ready += async () =>
        {
            await commands.RegisterCommandsGloballyAsync(true);
        };

        client.Log += Log;
        commands.Log += Log;

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var discordToken = config.GetValue<string>("DiscordToken");

        await client.LoginAsync(TokenType.Bot, discordToken);
        await client.StartAsync();
    }

    static Task Log(LogMessage arg)
    {
        Console.WriteLine(arg.Message);
        return Task.CompletedTask;
    }
}