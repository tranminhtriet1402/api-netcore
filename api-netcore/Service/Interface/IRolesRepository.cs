using api_netcore.DTO;
using System;
using System.Collections.Generic;

namespace api_netcore.Service.Interface
{
    public interface IRolesRepository
    {
        List<Roles> getAllRoles(string filter, string sort, int page, int pageSize);
        Roles getRolesId(Guid id);
        Roles addRole(Roles role);
        void updateRole(Guid id, Roles role);
        void deleteRole(Guid id);
    }
}
