namespace Eventee.Entities;

public class DiscordServer
{
    public int Id { get; set; }
    public ulong ServerId { get; set; }
    public ulong OwnerId { get; set; }
    public string Name { get; set; }
    public bool EventsEnabled { get; set; }
}