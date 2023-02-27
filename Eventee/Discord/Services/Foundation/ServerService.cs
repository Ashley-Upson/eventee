using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class ServerService : IServerService
{
    private readonly IServerBroker serverBroker;

    public ServerService(IServerBroker serverBroker)
    {
        this.serverBroker = serverBroker;
    }
    
    public ValueTask<Server> AddServerAsync(Server server)
    {
        return serverBroker.AddServerAsync(server);
    }

    public ValueTask<Server> UpdateServerAsync(Server server)
    {
        return serverBroker.UpdateServerAsync(server);
    }

    public async ValueTask DeleteServerAsync(Server server)
    {
        await serverBroker.DeleteServerAsync(server);
    }

    public IQueryable<Server> GetAllServers()
        => serverBroker.GetAllServers();
}