using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;

namespace Eventee.Discord.Services.Orchestration;

public class EventOrchestrationService : IEventOrchestrationService
{
    private readonly IEventProcessingService eventService;

    public EventOrchestrationService(IEventProcessingService eventService)
    {
        this.eventService = eventService;
    }
}