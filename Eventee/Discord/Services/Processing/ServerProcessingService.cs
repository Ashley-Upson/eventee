using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class ServerProcessingService : IServerProcessingService
{
    private readonly IServerService service;

    public ServerProcessingService(IServerService service)
    {
        this.service = service;
    }
    
    public ValueTask<Server> AddServerAsync(Server server)
    {
        return service.AddServerAsync(server);
    }

    public ValueTask<Server> UpdateServerAsync(Server server)
    {
        return service.UpdateServerAsync(server);
    }

    public async ValueTask DeleteServerAsync(Server server)
    {
        await service.DeleteServerAsync(server);
    }

    public IQueryable<Server> GetAllServers()
        => service.GetAllServers();
}