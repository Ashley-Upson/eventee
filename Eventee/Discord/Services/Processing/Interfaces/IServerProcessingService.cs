using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IServerProcessingService
{
    ValueTask<Server> AddServerAsync(Server server);

    ValueTask<Server> UpdateServerAsync(Server server);

    ValueTask DeleteServerAsync(Server server);

    IQueryable<Server> GetAllServers();
}