using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class RSVPProcessingService : IRSVPProcessingService
{
    private readonly IRSVPService service;

    public RSVPProcessingService(IRSVPService service)
    {
        this.service = service;
    }
    
    public ValueTask<RSVP> AddRSVPAsync(RSVP rsvp)
    {
        return service.AddRSVPAsync(rsvp);
    }

    public ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp)
    {
        return service.UpdateRSVPAsync(rsvp);
    }

    public async ValueTask DeleteRSVPAsync(RSVP rsvp)
    {
        await service.DeleteRSVPAsync(rsvp);
    }

    public IQueryable<RSVP> GetAllRSVPs()
        => service.GetAllRSVPs();
}