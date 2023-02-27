using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IRSVPProcessingService
{
    ValueTask<RSVP> AddRSVPAsync(RSVP rsvp);

    ValueTask<RSVP> UpdateRSVPAsync(RSVP rsvp);

    ValueTask DeleteRSVPAsync(RSVP rsvp);

    IQueryable<RSVP> GetAllRSVPs();
}