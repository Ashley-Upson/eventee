using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IMemberProcessingService
{
    ValueTask<Member> AddMemberAsync(Member member);

    ValueTask<Member> UpdateMemberAsync(Member member);

    ValueTask DeleteMemberAsync(Member member);

    IQueryable<Member> GetAllMembers();
}