using Eventee.Discord.Brokers.Eventee.Interfaces;
using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Foundation;

public class RoleService : IRoleService
{
    private readonly IRoleBroker roleBroker;

    public RoleService(IRoleBroker roleBroker)
    {
        this.roleBroker = roleBroker;
    }
    
    public ValueTask<Role> AddRoleAsync(Role role)
    {
        return roleBroker.AddRoleAsync(role);
    }

    public ValueTask<Role> UpdateRoleAsync(Role role)
    {
        return roleBroker.UpdateRoleAsync(role);
    }

    public async ValueTask DeleteRoleAsync(Role role)
    {
        await roleBroker.DeleteRoleAsync(role);
    }

    public IQueryable<Role> GetAllRoles()
        => roleBroker.GetAllRoles();
}