using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IReminderProcessingService
{
    ValueTask<Reminder> AddReminderAsync(Reminder reminder);

    ValueTask<Reminder> UpdateReminderAsync(Reminder reminder);

    ValueTask DeleteReminderAsync(Reminder reminder);

    IQueryable<Reminder> GetAllReminders();
}