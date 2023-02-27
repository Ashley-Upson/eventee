using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class EventBroker : IEventBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public EventBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Event> AddEventAsync(Event discordEvent)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Events.AddAsync(discordEvent);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Event> UpdateEventAsync(Event discordEvent)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Events.Update(discordEvent);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteEventAsync(Event discordEvent)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Events.Remove(discordEvent);
        await context.SaveChangesAsync();
    }

    public IQueryable<Event> GetAllEvents()
    {
        var context = contextFactory.CreateDbContext();
        return context.Events;
    }
}