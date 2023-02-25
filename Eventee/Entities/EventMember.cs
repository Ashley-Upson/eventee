namespace Eventee.Entities;

public class EventMember
{
    public ulong MemberId { get; set; }
    public ulong EventId { get; set; }
    
    public Member Member { get; set; }
    public Event Event { get; set; }
}