namespace Eventee.Entities;

public class Event
{
    public int Id { get; set; }
    public ulong ServerId { get; set; }
    public ulong OwnerId { get; set; }
    public ulong EventId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public bool IsPublic { get; set; }
    public string Status { get; set; }
    public int MinimumAcceptance { get; set; }

    public Server Server { get; set; }
    public ICollection<EventMember> EventMembers { get; set; }
    public ICollection<Reminder> Reminders { get; set; }
    public ICollection<RSVP> Rsvps { get; set; }
}