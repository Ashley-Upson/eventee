using System.Runtime.InteropServices;
using Discord.Interactions;

namespace Eventee.Discord.Modules;

public class EventeeModule : InteractionModuleBase<SocketInteractionContext>
{
    public InteractionService Commands { get; set; }

    [SlashCommand("eventee", "Interact with the Eventee Bot")]
    public async Task Eventee(string command)
    {
        await RespondAsync($"Hello {Context.User.Username}. You selected {command}");
    }
}