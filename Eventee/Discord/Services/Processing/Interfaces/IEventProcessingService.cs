using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IEventProcessingService
{
    ValueTask<Event> AddEventAsync(Event discordEvent);

    ValueTask<Event> UpdateEventAsync(Event discordEvent);

    ValueTask DeleteEventAsync(Event discordEvent);

    IQueryable<Event> GetAllEvents();
}