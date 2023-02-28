using Eventee.Discord.Services.Coordination.Interfaces;
using Eventee.Discord.Services.Orchestration.Interfaces;

namespace Eventee.Discord.Services.Coordination;

public class EventCoordinationService : IEventCoordinationService
{
    private readonly IEventOrchestrationService eventService;
    private readonly IMemberOrchestrationService memberService;
    private readonly IEventMemberOrchestrationService eventMemberService;

    public EventCoordinationService(IEventOrchestrationService eventService, IEventMemberOrchestrationService eventMemberService, IMemberOrchestrationService memberService)
    {
        this.eventService = eventService;
        this.eventMemberService = eventMemberService;
        this.memberService = memberService;
    }
    
    public ValueTask GetEvents() =>
        throw new NotImplementedException();
    
    public ValueTask CreateEvent() =>
        throw new NotImplementedException();

    public ValueTask DeleteEvent() =>
        throw new NotImplementedException();

    public ValueTask EditEventMinimumAcceptance() =>
        throw new NotImplementedException();

    public ValueTask InviteRequiredUserToEvent() =>
        throw new NotImplementedException();

    public ValueTask InviteOptionalUserToEvent() =>
        throw new NotImplementedException();

    public ValueTask RemoveUserFromEvent() =>
        throw new NotImplementedException();

    public ValueTask EditEventLocation() =>
        throw new NotImplementedException();

    public ValueTask EditEventDescription() =>
        throw new NotImplementedException();

    public ValueTask EditEventTitle() =>
        throw new NotImplementedException();

    public ValueTask EditEventStart() =>
        throw new NotImplementedException();

    public ValueTask EditEventEnd() =>
        throw new NotImplementedException();

    public ValueTask CancelEvent() =>
        throw new NotImplementedException();

    public ValueTask ConfirmEvent() =>
        throw new NotImplementedException();

    public ValueTask AcceptEventInvite() =>
        throw new NotImplementedException();

    public ValueTask DeclineEventInvite() =>
        throw new NotImplementedException();

    public ValueTask MaybeAcceptEventInvite() =>
        throw new NotImplementedException();
}