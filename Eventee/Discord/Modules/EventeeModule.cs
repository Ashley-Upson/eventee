using System.Runtime.InteropServices;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord.Brokers.Interfaces;
using Eventee.Discord.Services.Orchestration.Interfaces;

namespace Eventee.Discord.Modules;

public class EventeeModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly IDiscordOrchestrationService service;
    public InteractionService Commands { get; set; }

    public EventeeModule(IDiscordOrchestrationService service)
    {
        this.service = service;
    }

    [SlashCommand("eventee", "Interact with the Eventee Bot")]
    public async Task Eventee(string command)
    {
        // if (command.Data == "create")
        // {
        // await broker.RespondWithCreateEventModal(Context.Interaction);
    // }

    // await RespondAsync($"Hello {Context.User.Username}. You selected {command}");
    }
}