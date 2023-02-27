using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class EventService : IEventService
{
    private readonly IEventBroker discordEventBroker;

    public EventService(IEventBroker discordEventBroker)
    {
        this.discordEventBroker = discordEventBroker;
    }
    
    public ValueTask<Event> AddEventAsync(Event discordEvent)
    {
        return discordEventBroker.AddEventAsync(discordEvent);
    }

    public ValueTask<Event> UpdateEventAsync(Event discordEvent)
    {
        return discordEventBroker.UpdateEventAsync(discordEvent);
    }

    public async ValueTask DeleteEventAsync(Event discordEvent)
    {
        await discordEventBroker.DeleteEventAsync(discordEvent);
    }

    public IQueryable<Event> GetAllEvents()
        => discordEventBroker.GetAllEvents();
}