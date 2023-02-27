using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IChannelService
{
    ValueTask<Channel> AddChannelAsync(Channel channel);

    ValueTask<Channel> UpdateChannelAsync(Channel channel);

    ValueTask DeleteChannelAsync(Channel channel);

    IQueryable<Channel> GetAllChannels();
}