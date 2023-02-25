namespace Eventee.Entities;

public class EventReminder
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public DateTime ReminderTime { get; set; }
    public string ReminderType { get; set; }
    public ulong DestinationId { get; set; }
}