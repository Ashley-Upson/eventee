using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IEventMemberService
{
    ValueTask<EventMember> AddEventMemberAsync(EventMember eventMember);

    ValueTask<EventMember> UpdateEventMemberAsync(EventMember eventMember);

    ValueTask DeleteEventMemberAsync(EventMember eventMember);

    IQueryable<EventMember> GetAllEventMembers();
}