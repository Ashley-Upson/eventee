using Discord;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IDiscordService
{
    ModalBuilder NewModalBuilder();
}