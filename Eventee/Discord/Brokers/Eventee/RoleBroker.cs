using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Entities;
using Eventee.Entities.Contexts.Interfaces;

namespace Eventee.Discord.Brokers.Eventee;

public class RoleBroker : IRoleBroker
{
    private readonly IEventeeDbContextFactory contextFactory;

    public RoleBroker(IEventeeDbContextFactory contextFactory)
        => this.contextFactory = contextFactory;

    public async ValueTask<Role> AddRoleAsync(Role role)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Role> UpdateRoleAsync(Role role)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Roles.Update(role);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteRoleAsync(Role role)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Roles.Remove(role);
        await context.SaveChangesAsync();
    }

    public IQueryable<Role> GetAllRoles()
    {
        var context = contextFactory.CreateDbContext();
        return context.Roles;
    }
}