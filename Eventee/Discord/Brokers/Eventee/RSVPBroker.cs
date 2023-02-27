using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class RSVPBroker : IRSVPBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public RSVPBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<RSVP> AddRSVPAsync(RSVP rsvp)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.RSVPs.AddAsync(rsvp);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.RSVPs.Update(rsvp);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteRSVPAsync(RSVP rsvp)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.RSVPs.Remove(rsvp);
        await context.SaveChangesAsync();
    }

    public IQueryable<RSVP> GetAllRSVPs()
    {
        var context = contextFactory.CreateDbContext();
        return context.RSVPs;
    }
}