using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IChannelProcessingService
{
    ValueTask<Channel> AddChannelAsync(Channel channel);

    ValueTask<Channel> UpdateChannelAsync(Channel channel);

    ValueTask DeleteChannelAsync(Channel channel);

    IQueryable<Channel> GetAllChannels();
}