using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;

namespace Eventee.Discord.Services.Orchestration;

public class EventMemberOrchestrationService : IEventMemberOrchestrationService
{
    private readonly IEventMemberProcessingService eventMemberService;

    public EventMemberOrchestrationService(IEventMemberProcessingService eventMemberService)
    {
        this.eventMemberService = eventMemberService;
    }
}