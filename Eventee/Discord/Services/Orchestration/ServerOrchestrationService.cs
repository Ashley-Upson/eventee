using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Orchestration;

public class ServerOrchestrationService : IServerOrchestrationService
{
    private readonly IServerProcessingService serverService;
    private readonly IChannelProcessingService channelService;
    private readonly IRoleProcessingService roleService;

    public ServerOrchestrationService(IServerProcessingService serverService, IChannelProcessingService channelService, IRoleProcessingService roleService)
    {
        this.serverService = serverService;
        this.channelService = channelService;
        this.roleService = roleService;
    }

    public ValueTask SetupServer() =>
        throw new NotImplementedException();

    public ValueTask DropServer() =>
        throw new NotImplementedException();

    public ValueTask AddAdminRole() =>
        throw new NotImplementedException();

    public ValueTask RemoveAdminRole() =>
        throw new NotImplementedException();

    public ValueTask AddManagerRole() =>
        throw new NotImplementedException();

    public ValueTask RemoveManagerRole() =>
        throw new NotImplementedException();

    public ValueTask AddCreatorRole() =>
        throw new NotImplementedException();

    public ValueTask RemoveCreatorRole() =>
        throw new NotImplementedException();

    public ValueTask EnableDiscordEvents() =>
        throw new NotImplementedException();

    public ValueTask DisableDiscordEvents() =>
        throw new NotImplementedException();
}