using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IReminderService
{
    ValueTask<Reminder> AddReminderAsync(Reminder reminder);

    ValueTask<Reminder> UpdateReminderAsync(Reminder reminder);

    ValueTask DeleteReminderAsync(Reminder reminder);

    IQueryable<Reminder> GetAllReminders();
}