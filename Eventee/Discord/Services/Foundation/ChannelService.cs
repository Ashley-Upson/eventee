using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class ChannelService : IChannelService
{
    private readonly IChannelBroker channelBroker;

    public ChannelService(IChannelBroker channelBroker)
    {
        this.channelBroker = channelBroker;
    }
    
    public ValueTask<Channel> AddChannelAsync(Channel channel)
    {
        return channelBroker.AddChannelAsync(channel);
    }

    public ValueTask<Channel> UpdateChannelAsync(Channel channel)
    {
        return channelBroker.UpdateChannelAsync(channel);
    }

    public async ValueTask DeleteChannelAsync(Channel channel)
    {
        await channelBroker.DeleteChannelAsync(channel);
    }

    public IQueryable<Channel> GetAllChannels()
        => channelBroker.GetAllChannels();
}