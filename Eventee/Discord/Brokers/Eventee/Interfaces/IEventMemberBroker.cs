using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IEventMemberBroker
{
    ValueTask<EventMember> AddEventMemberAsync(EventMember eventEventMember);

    ValueTask<EventMember> UpdateEventMemberAsync(EventMember eventEventMember);

    ValueTask DeleteEventMemberAsync(EventMember eventEventMember);

    IQueryable<EventMember> GetAllEventMembers();
}