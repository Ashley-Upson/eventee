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

    public DbSet<Server> DiscordServers { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<EventMember> EventMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Server>()
            .HasMany(server => server.Channels)
            .WithOne(channel => channel.Server)
            .HasForeignKey(channel => channel.ServerId);

        builder.Entity<Server>()
            .HasMany(server => server.Roles)
            .WithOne(rsvp => rsvp.Server)
            .HasForeignKey(rsvp => rsvp.ServerId);

        builder.Entity<Server>()
            .HasMany(server => server.Events)
            .WithOne(discordEvent => discordEvent.Server)
            .HasForeignKey(discordEvent => discordEvent.ServerId);

        builder.Entity<EventMember>()
            .HasKey(eventMember => new
            {
                eventMember.MemberId,
                eventMember.EventId
            });

        builder.Entity<EventMember>()
            .HasOne(eventMember => eventMember.Event)
            .WithMany(member => member.EventMembers)
            .HasForeignKey(eventMember => eventMember.EventId);

        builder.Entity<EventMember>()
            .HasOne(eventMember => eventMember.Member)
            .WithMany(member => member.EventMembers)
            .HasForeignKey(eventMember => eventMember.MemberId);

        builder.Entity<Event>()
            .HasMany(discordEvent => discordEvent.Reminders)
            .WithOne(reminder => reminder.Event)
            .HasForeignKey(reminder => reminder.EventId);

        builder.Entity<Channel>()
            .HasOne(channel => channel.Server)
            .WithMany(server => server.Channels)
            .HasForeignKey(channel => channel.ServerId);

        builder.Entity<Role>()
            .HasOne(role => role.Server)
            .WithMany(server => server.Roles)
            .HasForeignKey(role => role.ServerId);

        builder.Entity<RSVP>()
            .HasOne(rsvp => rsvp.Event)
            .WithMany(discordEvent => discordEvent.Rsvps)
            .HasForeignKey(rsvp => rsvp.EventId);

        builder.Entity<RSVP>()
            .HasOne(rsvp => rsvp.Member)
            .WithMany(discordEvent => discordEvent.Rsvps)
            .HasForeignKey(rsvp => rsvp.MemberId);
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