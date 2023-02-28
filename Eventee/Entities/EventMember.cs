namespace Eventee.Entities;

public class EventMember
{
    public ulong MemberId { get; set; }
    public int EventId { get; set; }
    public bool Required { get; set; }

    public Member Member { get; set; }
    public Event Event { get; set; }
}