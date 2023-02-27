using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IRSVPService
{
    ValueTask<RSVP> AddRsvpAsync(RSVP rsvp);

    ValueTask<RSVP> UpdateRsvpAsync(RSVP rsvp);

    ValueTask DeleteRsvpAsync(RSVP rsvp);

    IQueryable<RSVP> GetAllRsvps();
}