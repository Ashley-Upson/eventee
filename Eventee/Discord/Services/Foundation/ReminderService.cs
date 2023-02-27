using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class ReminderService : IReminderService
{
    private readonly IReminderBroker reminderBroker;

    public ReminderService(IReminderBroker reminderBroker)
    {
        this.reminderBroker = reminderBroker;
    }
    
    public ValueTask<Reminder> AddReminderAsync(Reminder reminder)
    {
        return reminderBroker.AddReminderAsync(reminder);
    }

    public ValueTask<Reminder> UpdateReminderAsync(Reminder reminder)
    {
        return reminderBroker.UpdateReminderAsync(reminder);
    }

    public async ValueTask DeleteReminderAsync(Reminder reminder)
    {
        await reminderBroker.DeleteReminderAsync(reminder);
    }

    public IQueryable<Reminder> GetAllReminders()
        => reminderBroker.GetAllReminders();
}