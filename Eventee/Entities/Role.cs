namespace Eventee.Entities;

public class Role
{
    public int Id { get; set; }
    public ulong ServerId { get; set; }
    public bool CanCreateEvents { get; set; }
    public bool CanManageEvents { get; set; }
    public bool IsAdminRole { get; set; }
}