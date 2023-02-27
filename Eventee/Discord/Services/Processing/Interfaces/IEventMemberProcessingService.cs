using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IEventMemberProcessingService
{
    ValueTask<EventMember> AddEventMemberAsync(EventMember eventMember);

    ValueTask<EventMember> UpdateEventMemberAsync(EventMember eventMember);

    ValueTask DeleteEventMemberAsync(EventMember eventMember);

    IQueryable<EventMember> GetAllEventMembers();
}