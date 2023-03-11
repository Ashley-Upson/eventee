using Discord;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;

namespace Eventee.Discord.Services.Processing;

public class DiscordProcessingService : IDiscordProcessingService
{
    private readonly IDiscordService service;

    public DiscordProcessingService(IDiscordService service)
    {
        this.service = service;
    }

    public ModalBuilder CreateEventModal(ulong guildID)
    {
        ModalBuilder builder = this.service.NewModalBuilder();
        
        string id = guildID.ToString();
        
        builder
            .WithTitle("Create a new event")
            .WithCustomId("create_" + id)
            .AddTextInput("Event name", "name", TextInputStyle.Short, null, 1, null, true)
            .AddTextInput("Event description", "description")
            .AddTextInput("Location", "location")
            .AddTextInput("Date & time", "date_time", TextInputStyle.Short, "2023-03-30 23:45")
            .AddTextInput("Duration", "duration", TextInputStyle.Short, "30m / 2h / 3d / 4w / 4w 3d 2h 21m. Default 1h", null, null, true, "1h");

        return builder;
    }
}