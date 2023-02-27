namespace Eventee.Entities.Contexts.Interfaces;

public interface IEventeeDbContextFactory
{
    EventeeDbContext CreateDbContext();
}