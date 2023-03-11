using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Eventee.Discord.Brokers.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Eventee.Discord;

public class DiscordBot
{
    private readonly DiscordSocketClient client;
    private readonly ILoggingBroker logBroker;
    private readonly InteractionService interactionService;

    public DiscordBot(DiscordSocketClient client, ILoggingBroker logBroker, InteractionService interactionService)
    {
        this.client = client;
        this.logBroker = logBroker;
        this.interactionService = interactionService;
    }

    public async Task InitialiseDiscordBot(string token)
    {
        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();
        await client.SetGameAsync("with events!");
        this.AttachLogger();
        this.AttachEventHandlers();
    }
    
    private void AttachLogger()
    {
        client.Log += logBroker.Log;
        interactionService.Log += logBroker.Log;
    }

    private void RegisterCommands()
        => client.Ready += async () => { await interactionService.RegisterCommandsGloballyAsync(true); };

    private void AttachEventHandlers()
    {
        client.ModalSubmitted += HandleModalSubmittedEvent;
    }

    public async Task SendMessageToChannel(ulong channel, string message)
        => await GetChannelSocket(channel)
            .SendMessageAsync(text: message);
    
    private ISocketMessageChannel GetChannelSocket(ulong channel)
        => client.GetChannel(channel) as ISocketMessageChannel;

    private IGuild GetServer(ulong server)
        => client.GetGuild(server);

    private async Task HandleModalSubmittedEvent(SocketModal modal)
    {
        // Get the values of components.
        List<SocketMessageComponentData> components = modal.Data.Components.ToList();
        string food = components.First(x => x.CustomId == "name").Value;
        string reason = components.First(x => x.CustomId == "description").Value;

        // Build the message to send.
        string message = "hey @everyone; I just learned " + $"{modal.User.Mention}'s event is " + $"{food} because {reason}.";

        // Specify the AllowedMentions so we don't actually ping everyone.
        AllowedMentions mentions = new AllowedMentions();
        mentions.AllowedTypes = AllowedMentionTypes.Users;

        // Respond to the modal.
        await modal.RespondAsync(message, allowedMentions: mentions);
    }
}