using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class ChannelProcessingService : IChannelProcessingService
{
    private readonly IChannelService service;

    public ChannelProcessingService(IChannelService service)
    {
        this.service = service;
    }
    
    public ValueTask<Channel> AddChannelAsync(Channel server)
    {
        return service.AddChannelAsync(server);
    }

    public ValueTask<Channel> UpdateChannelAsync(Channel server)
    {
        return service.UpdateChannelAsync(server);
    }

    public async ValueTask DeleteChannelAsync(Channel server)
    {
        await service.DeleteChannelAsync(server);
    }

    public IQueryable<Channel> GetAllChannels()
        => service.GetAllChannels();
}