using Eventee.Entities.Contexts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Eventee.Entities.Contexts;

public class EventeeDbContextFactory : IEventeeDbContextFactory
{
    private readonly IConfiguration configuration;

    public EventeeDbContextFactory(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public EventeeDbContext CreateDbContext()
        => new EventeeDbContext(configuration);
}