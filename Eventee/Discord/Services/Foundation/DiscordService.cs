using Discord;
using Eventee.Discord.Brokers.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;

namespace Eventee.Discord.Services.Foundation;

public class DiscordService : IDiscordService
{
    private readonly IDiscordBroker discordBroker;

    public DiscordService(IDiscordBroker discordBroker)
    {
        this.discordBroker = discordBroker;
    }

    public ModalBuilder NewModalBuilder()
        => this.discordBroker.NewModalBuilder();
}