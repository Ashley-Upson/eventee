namespace Eventee.Entities;

public class Channel
{
    public int Id { get; set; }
    public ulong ServerId { get; set; }
    public bool IsReminderChannel { get; set; }
    public bool IsAllowedInteraction { get; set; }
}