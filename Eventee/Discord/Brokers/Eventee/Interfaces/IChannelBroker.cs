using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IChannelBroker
{
    ValueTask<Channel> AddChannelAsync(Channel channel);

    ValueTask<Channel> UpdateChannelAsync(Channel channel);

    ValueTask DeleteChannelAsync(Channel channel);

    IQueryable<Channel> GetAllChannels();
}