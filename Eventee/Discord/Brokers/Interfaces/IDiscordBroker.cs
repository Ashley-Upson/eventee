using Discord;
using Discord.WebSocket;

namespace Eventee.Discord.Brokers.Interfaces;

public interface IDiscordBroker
{
    ModalBuilder NewModalBuilder();
    Task RespondWithCreateEventModal(SocketInteraction interaction, ModalBuilder builder);
}