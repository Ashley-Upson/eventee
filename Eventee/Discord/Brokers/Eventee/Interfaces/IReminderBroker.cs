using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IReminderBroker
{
    ValueTask<Reminder> AddReminderAsync(Reminder reminder);

    ValueTask<Reminder> UpdateReminderAsync(Reminder reminder);

    ValueTask DeleteReminderAsync(Reminder reminder);

    IQueryable<Reminder> GetAllReminders();
}