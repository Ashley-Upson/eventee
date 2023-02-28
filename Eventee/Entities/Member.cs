namespace Eventee.Entities;

public class Member
{
    public ulong Id { get; set; }
    public string Username { get; set; }
    
    public Event Event { get; set; }
    public ICollection<RSVP> Rsvps { get; set; }
    public ICollection<EventMember> EventMembers { get; set; }
}