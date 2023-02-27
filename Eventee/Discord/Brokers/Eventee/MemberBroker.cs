using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class MemberBroker : IMemberBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public MemberBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Member> AddMemberAsync(Member member)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Members.AddAsync(member);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Member> UpdateMemberAsync(Member member)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Members.Update(member);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteMemberAsync(Member member)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Members.Remove(member);
        await context.SaveChangesAsync();
    }

    public IQueryable<Member> GetAllMembers()
    {
        var context = contextFactory.CreateDbContext();
        return context.Members;
    }
}