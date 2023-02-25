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

    public DbSet<DiscordServer> DiscordServers { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventMember> EventMembers { get; set; }
    public DbSet<EventReminder> EventReminders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<DiscordServer>()
            .HasMany(s => s.Channels)
            .WithOne(c => c.Server)
            .HasForeignKey(c => c.ServerId);

        builder.Entity<DiscordServer>()
            .HasMany(s => s.Roles)
            .WithOne(r => r.Server)
            .HasForeignKey(r => r.ServerId);

        builder.Entity<DiscordServer>()
            .HasMany(s => s.Events)
            .WithOne(e => e.Server)
            .HasForeignKey(e => e.ServerId);

        builder.Entity<Event>()
            .HasMany(e => e.Members)
            .WithMany(em => em.Events)
            .UsingEntity<Dictionary<string, object>>(
                "EventMemberEvent",
                j => j.HasOne<EventMember>().WithMany().HasForeignKey("MemberId"),
                j => j.HasOne<Event>().WithMany().HasForeignKey("EventId")
            );

        builder.Entity<Event>()
            .HasMany(e => e.Reminders)
            .WithOne(er => er.Event)
            .HasForeignKey(er => er.EventId);

        builder.Entity<Channel>()
            .HasOne(c => c.Server)
            .WithMany(s => s.Channels)
            .HasForeignKey(c => c.ServerId);

        builder.Entity<Role>()
            .HasOne(r => r.Server)
            .WithMany(s => s.Roles)
            .HasForeignKey(r => r.ServerId);
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
}