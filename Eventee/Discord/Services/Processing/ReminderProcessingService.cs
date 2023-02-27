using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class ReminderProcessingService : IReminderProcessingService
{
    private readonly IReminderService service;

    public ReminderProcessingService(IReminderService service)
    {
        this.service = service;
    }
    
    public ValueTask<Reminder> AddReminderAsync(Reminder server)
    {
        return service.AddReminderAsync(server);
    }

    public ValueTask<Reminder> UpdateReminderAsync(Reminder server)
    {
        return service.UpdateReminderAsync(server);
    }

    public async ValueTask DeleteReminderAsync(Reminder server)
    {
        await service.DeleteReminderAsync(server);
    }

    public IQueryable<Reminder> GetAllReminders()
        => service.GetAllReminders();
}