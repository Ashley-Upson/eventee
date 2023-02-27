using Eventee.Discord.Services.Foundation.Interfaces;
using Eventee.Discord.Services.Processing.Interfaces;
using Eventee.Entities;

namespace Eventee.Discord.Services.Processing;

public class RoleProcessingService : IRoleProcessingService
{
    private readonly IRoleService service;

    public RoleProcessingService(IRoleService service)
    {
        this.service = service;
    }
    
    public ValueTask<Role> AddRoleAsync(Role server)
    {
        return service.AddRoleAsync(server);
    }

    public ValueTask<Role> UpdateRoleAsync(Role server)
    {
        return service.UpdateRoleAsync(server);
    }

    public async ValueTask DeleteRoleAsync(Role server)
    {
        await service.DeleteRoleAsync(server);
    }

    public IQueryable<Role> GetAllRoles()
        => service.GetAllRoles();
}