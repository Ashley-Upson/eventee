using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IServerService
{
    ValueTask<Server> AddServerAsync(Server server);

    ValueTask<Server> UpdateServerAsync(Server server);

    ValueTask DeleteServerAsync(Server server);

    IQueryable<Server> GetAllServers();
}