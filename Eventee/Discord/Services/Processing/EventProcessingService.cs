using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class EventProcessingService : IEventProcessingService
{
    private readonly IEventService service;

    public EventProcessingService(IEventService service)
    {
        this.service = service;
    }
    
    public ValueTask<Event> AddEventAsync(Event discordEvent)
    {
        return service.AddEventAsync(discordEvent);
    }

    public ValueTask<Event> UpdateEventAsync(Event discordEvent)
    {
        return service.UpdateEventAsync(discordEvent);
    }

    public async ValueTask DeleteEventAsync(Event discordEvent)
    {
        await service.DeleteEventAsync(discordEvent);
    }

    public IQueryable<Event> GetAllEvents()
        => service.GetAllEvents();
}