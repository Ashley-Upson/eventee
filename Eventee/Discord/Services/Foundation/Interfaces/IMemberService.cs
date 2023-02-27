using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IMemberService
{
    ValueTask<Member> AddMemberAsync(Member member);

    ValueTask<Member> UpdateMemberAsync(Member member);

    ValueTask DeleteMemberAsync(Member member);

    IQueryable<Member> GetAllMembers();
}