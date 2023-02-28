using Eventee.Discord.Services.Orchestration.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;

namespace Eventee.Discord.Services.Orchestration;

public class MemberOrchestrationService : IMemberOrchestrationService
{
    private readonly IMemberProcessingService memberService;

    public MemberOrchestrationService(IMemberProcessingService memberService)
    {
        this.memberService = memberService;
    }
}