using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IEventBroker
{
    ValueTask<Event> AddEventAsync(Event discordEvent);

    ValueTask<Event> UpdateEventAsync(Event discordEvent);

    ValueTask DeleteEventAsync(Event discordEvent);

    IQueryable<Event> GetAllEvents();
}