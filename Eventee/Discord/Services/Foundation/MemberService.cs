using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class MemberService : IMemberService
{
    private readonly IMemberBroker memberBroker;

    public MemberService(IMemberBroker memberBroker)
    {
        this.memberBroker = memberBroker;
    }
    
    public ValueTask<Member> AddMemberAsync(Member member)
    {
        return memberBroker.AddMemberAsync(member);
    }

    public ValueTask<Member> UpdateMemberAsync(Member member)
    {
        return memberBroker.UpdateMemberAsync(member);
    }

    public async ValueTask DeleteMemberAsync(Member member)
    {
        await memberBroker.DeleteMemberAsync(member);
    }

    public IQueryable<Member> GetAllMembers()
        => memberBroker.GetAllMembers();
}