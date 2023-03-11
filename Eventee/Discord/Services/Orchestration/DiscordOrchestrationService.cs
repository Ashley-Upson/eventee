using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Orchestration;

public class DiscordOrchestrationService : IDiscordOrchestrationService
{
    private readonly IDiscordProcessingService service;

    public DiscordOrchestrationService(IDiscordProcessingService service)
    {
        this.service = service;
    }
}