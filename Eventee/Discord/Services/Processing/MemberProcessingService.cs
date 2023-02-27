using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class MemberProcessingService : IMemberProcessingService
{
    private readonly IMemberService service;

    public MemberProcessingService(IMemberService service)
    {
        this.service = service;
    }
    
    public ValueTask<Member> AddMemberAsync(Member server)
    {
        return service.AddMemberAsync(server);
    }

    public ValueTask<Member> UpdateMemberAsync(Member server)
    {
        return service.UpdateMemberAsync(server);
    }

    public async ValueTask DeleteMemberAsync(Member server)
    {
        await service.DeleteMemberAsync(server);
    }

    public IQueryable<Member> GetAllMembers()
        => service.GetAllMembers();
}