using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IRSVPService
{
    ValueTask<RSVP> AddRSVPAsync(RSVP rsvp);

    ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp);

    ValueTask DeleteRSVPAsync(RSVP rsvp);

    IQueryable<RSVP> GetAllRSVPs();
}