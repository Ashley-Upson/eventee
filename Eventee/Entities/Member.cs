namespace Eventee.Entities;

public class Member
{
    public int Id { get; set; }
    public ulong MemberId { get; set; }
    public int EventId { get; set; }
    public string Username { get; set; }
    public bool Required { get; set; }
    
    public ICollection<Event> Events { get; set; }
    public ICollection<DiscordServer> Servers { get; set; }
    public ICollection<RSVP> Rsvps { get; set; }
}