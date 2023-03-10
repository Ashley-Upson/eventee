using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Orchestration;

public class ServerOrchestrationService : IServerOrchestrationService
{
    private readonly IServerProcessingService serverService;

    public ServerOrchestrationService(IServerProcessingService serverService)
    {
        this.serverService = serverService;
    }
}