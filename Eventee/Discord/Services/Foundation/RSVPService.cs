using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class RSVPService : IRSVPService
{
    private readonly IRSVPBroker rsvpBroker;

    public RSVPService(IRSVPBroker rsvpBroker)
    {
        this.rsvpBroker = rsvpBroker;
    }
    
    public ValueTask<RSVP> AddRSVPAsync(RSVP rsvp)
    {
        return rsvpBroker.AddRSVPAsync(rsvp);
    }

    public ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp)
    {
        return rsvpBroker.UpdateRSVPAsync(rsvp);
    }

    public async ValueTask DeleteRSVPAsync(RSVP rsvp)
    {
        await rsvpBroker.DeleteRSVPAsync(rsvp);
    }

    public IQueryable<RSVP> GetAllRSVPs()
        => rsvpBroker.GetAllRSVPs();
}