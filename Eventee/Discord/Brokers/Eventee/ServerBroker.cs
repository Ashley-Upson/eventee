using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class ServerBroker : IServerBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public ServerBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Server> AddServerAsync(Server server)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Servers.AddAsync(server);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Server> UpdateServerAsync(Server server)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Servers.Update(server);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteServerAsync(Server server)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Servers.Remove(server);
        await context.SaveChangesAsync();
    }

    public IQueryable<Server> GetAllServers()
    {
        var context = contextFactory.CreateDbContext();
        return context.Servers;
    }
}