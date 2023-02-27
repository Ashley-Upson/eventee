using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class ChannelBroker : IChannelBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public ChannelBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Channel> AddChannelAsync(Channel channel)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Channels.AddAsync(channel);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Channel> UpdateChannelAsync(Channel channel)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Channels.Update(channel);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteChannelAsync(Channel channel)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Channels.Remove(channel);
        await context.SaveChangesAsync();
    }

    public IQueryable<Channel> GetAllChannels()
    {
        var context = contextFactory.CreateDbContext();
        return context.Channels;
    }
}