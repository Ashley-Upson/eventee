namespace Eventee.Entities;

public class Channel
{
    public ulong Id { get; set; }
    public ulong ServerId { get; set; }
    public bool IsReminderChannel { get; set; }
    public bool IsAllowedInteraction { get; set; }
    
    public Server Server { get; set; }
}