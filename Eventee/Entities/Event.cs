namespace Eventee.Entities;

public class Event
{
    public int Id { get; set; }
    public ulong ServerId { get; set; }
    public ulong OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public bool IsPublic { get; set; }
}