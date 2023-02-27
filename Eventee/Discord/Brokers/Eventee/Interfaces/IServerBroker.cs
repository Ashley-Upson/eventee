using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IServerBroker
{
    ValueTask<Server> AddServerAsync(Server server);

    ValueTask<Server> UpdateServerAsync(Server server);

    ValueTask DeleteServerAsync(Server server);

    IQueryable<Server> GetAllServers();
}