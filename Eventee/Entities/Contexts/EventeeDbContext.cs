using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Eventee.Entities.Contexts;

public class EventeeDbContext : DbContext
{
    private readonly IConfiguration config;

    public EventeeDbContext(IConfiguration config)
    {
        this.config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<DiscordServer>()
            .HasMany(server => server.Events)
            .WithOne(discordEvent => discordEvent.DiscordServer)
            .HasForeignKey(discordEvent => discordEvent.ServerId);

        builder.Entity<Event>()
            .HasOne(discordEvent => discordEvent.DiscordServer)
            .WithMany(server => server.Event)
            .HasForeignKey(server => server.ServerId);

        builder.Entity<Event>()
            .HasMany(discordEvent => discordEvent.EventMembers)
            .WithMany(member => member.Events);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var serverVersion = new MariaDbServerVersion(new Version(10, 5));
        
        optionsBuilder.UseMySql(this.config.GetConnectionString("Eventee"), serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<DiscordServer> DiscordServers { get; set; }
}