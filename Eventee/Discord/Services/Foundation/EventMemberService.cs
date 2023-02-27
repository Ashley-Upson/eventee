using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class EventMemberService : IEventMemberService
{
    private readonly IEventMemberBroker eventMemberBroker;

    public EventMemberService(IEventMemberBroker eventMemberBroker)
    {
        this.eventMemberBroker = eventMemberBroker;
    }
    
    public ValueTask<EventMember> AddEventMemberAsync(EventMember eventMember)
    {
        return eventMemberBroker.AddEventMemberAsync(eventMember);
    }

    public ValueTask<EventMember> UpdateEventMemberAsync(EventMember eventMember)
    {
        return eventMemberBroker.UpdateEventMemberAsync(eventMember);
    }

    public async ValueTask DeleteEventMemberAsync(EventMember eventMember)
    {
        await eventMemberBroker.DeleteEventMemberAsync(eventMember);
    }

    public IQueryable<EventMember> GetAllEventMembers()
        => eventMemberBroker.GetAllEventMembers();
}