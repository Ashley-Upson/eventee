using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class ReminderBroker : IReminderBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public ReminderBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Reminder> AddReminderAsync(Reminder reminder)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Reminders.AddAsync(reminder);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Reminder> UpdateReminderAsync(Reminder reminder)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Reminders.Update(reminder);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteReminderAsync(Reminder reminder)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Reminders.Remove(reminder);
        await context.SaveChangesAsync();
    }

    public IQueryable<Reminder> GetAllReminders()
    {
        var context = contextFactory.CreateDbContext();
        return context.Reminders;
    }
}