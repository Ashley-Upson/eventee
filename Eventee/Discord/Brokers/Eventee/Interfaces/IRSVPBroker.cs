using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IRSVPBroker
{
    ValueTask<RSVP> AddRSVPAsync(RSVP rsvp);

    ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp);

    ValueTask DeleteRSVPAsync(RSVP rsvp);

    IQueryable<RSVP> GetAllRSVPs();
}