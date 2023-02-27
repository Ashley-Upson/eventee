using Eventee.Entities;

namespace Eventee.Discord.Brokers.Eventee.Interfaces;

public interface IRoleBroker
{
    ValueTask<Role> AddRoleAsync(Role role);

    ValueTask<Role> UpdateRoleAsync(Role role);

    ValueTask DeleteRoleAsync(Role role);

    IQueryable<Role> GetAllRoles();
}