namespace Eventee.Entities;

public class Member
{
    public int Id { get; set; }
    public ulong MemberId { get; set; }
    public string Username { get; set; }
    public bool Required { get; set; }
    
    public Event Event { get; set; }
    public RSVP Rsvp { get; set; }
    public ICollection<EventMember> EventMembers { get; set; }
}