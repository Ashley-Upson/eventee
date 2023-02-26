using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;

namespace Eventee.Discord.Modules;

public class GreetCommand : ModuleBase<SocketCommandContext>
{
    [SlashCommand("newgreet", "Greets the user.")]
    public async Task GreetAsync(SocketSlashCommand command)
    {
        string user = command.User.Mention;
        await command.RespondAsync($"Hello, {user}!");
    }
}
