namespace Eventee.Entities;

public class RSVP
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public ulong MemberId { get; set; }
    public string Attendance { get; set; }
    
    public Event Event { get; set; }
    public Member Member { get; set; }
}