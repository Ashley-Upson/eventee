using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation.Interfaces;

public interface IRoleService
{
    ValueTask<Role> AddRoleAsync(Role role);

    ValueTask<Role> UpdateRoleAsync(Role role);

    ValueTask DeleteRoleAsync(Role role);

    IQueryable<Role> GetAllRoles();
}