namespace Eventee.Entities;

public class EventMember
{
    public int Id { get; set; }
    public ulong MemberId { get; set; }
    public int EventId { get; set; }
    public string Username { get; set; }
}