using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IEventService
{
    ValueTask<Event> AddEventAsync(Event discordEvent);

    ValueTask<Event> UpdateEventAsync(Event discordEvent);

    ValueTask DeleteEventAsync(Event discordEvent);

    IQueryable<Event> GetAllEvents();
}