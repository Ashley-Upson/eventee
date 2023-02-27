using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class EventMemberBroker : IEventMemberBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public EventMemberBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<EventMember> AddEventMemberAsync(EventMember eventMember)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.EventMembers.AddAsync(eventMember);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<EventMember> UpdateEventMemberAsync(EventMember eventMember)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.EventMembers.Update(eventMember);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteEventMemberAsync(EventMember eventMember)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.EventMembers.Remove(eventMember);
        await context.SaveChangesAsync();
    }

    public IQueryable<EventMember> GetAllEventMembers()
    {
        var context = contextFactory.CreateDbContext();
        return context.EventMembers;
    }
}