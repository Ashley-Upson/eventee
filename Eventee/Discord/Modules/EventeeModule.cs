using Discord.Interactions;

namespace Eventee.Discord.Modules;

public class EventeeModule : InteractionModuleBase<SocketInteractionContext>
{
    public InteractionService Commands { get; set; }

    // Basic slash command. [SlashCommand("name", "description")]
    // Similar to text command creation, and their respective attributes
    [SlashCommand("eventeeping", "Receive a pong!")]
    public async Task Ping()
    {
        await RespondAsync("pong");
    }

    [SlashCommand("eventeegreet", "say hello to the caller!")]
    public async Task Greet()
    {
        await RespondAsync($"Hello {Context.User.Username}");
    }
}