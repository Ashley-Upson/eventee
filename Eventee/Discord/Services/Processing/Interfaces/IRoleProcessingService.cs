using Eventee.Entities;

namespace Eventee.Discord.Services.Processing.Interfaces;

public interface IRoleProcessingService
{
    ValueTask<Role> AddRoleAsync(Role role);

    ValueTask<Role> UpdateRoleAsync(Role role);

    ValueTask DeleteRoleAsync(Role role);

    IQueryable<Role> GetAllRoles();
}