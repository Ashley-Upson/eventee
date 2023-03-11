using Discord;
using Discord.WebSocket;
using Eventee.Discord.Brokers.Interfaces;

namespace Eventee.Discord.Brokers;

public class DiscordBroker : IDiscordBroker
{
    private readonly DiscordBot bot;

    public DiscordBroker(DiscordBot bot)
    {
        this.bot = bot;
    }

    public ModalBuilder NewModalBuilder()
        => new ModalBuilder();

    public async Task RespondWithCreateEventModal(SocketInteraction interaction, ModalBuilder builder)
    {
        await interaction.RespondWithModalAsync(builder.Build());
    }
}