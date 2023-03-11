using Discord.WebSocket;

namespace Eventee.Discord.Brokers;

public class DiscordSlashCommandBroker
{
    public async Task RespondToSlashCommandWithText(SocketSlashCommand command, string message)
        => await command.RespondAsync(text: message);
}