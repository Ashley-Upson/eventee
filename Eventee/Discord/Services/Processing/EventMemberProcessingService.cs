using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class EventMemberProcessingService : IEventMemberProcessingService
{
    private readonly IEventMemberService service;

    public EventMemberProcessingService(IEventMemberService service)
    {
        this.service = service;
    }
    
    public ValueTask<EventMember> AddEventMemberAsync(EventMember server)
    {
        return service.AddEventMemberAsync(server);
    }

    public ValueTask<EventMember> UpdateEventMemberAsync(EventMember server)
    {
        return service.UpdateEventMemberAsync(server);
    }

    public async ValueTask DeleteEventMemberAsync(EventMember server)
    {
        await service.DeleteEventMemberAsync(server);
    }

    public IQueryable<EventMember> GetAllEventMembers()
        => service.GetAllEventMembers();
}