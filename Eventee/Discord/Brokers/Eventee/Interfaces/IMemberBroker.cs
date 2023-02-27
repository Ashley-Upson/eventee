using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IMemberBroker
{
    ValueTask<Member> AddMemberAsync(Member member);

    ValueTask<Member> UpdateMemberAsync(Member member);

    ValueTask DeleteMemberAsync(Member member);

    IQueryable<Member> GetAllMembers();
}