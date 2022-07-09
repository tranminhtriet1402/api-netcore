using api_netcore.DTO;
using System;
using System.Collections.Generic;

namespace api_netcore.Service.Interface
{
    public interface IRolesRepository
    {
        List<RolesDTO> getAllRoles(string filter, string sort, int page, int pageSize);
        RolesDTO getRolesId(Guid id);
        RolesDTO addRole(RolesDTO role);
        void updateRole(Guid id, RolesDTO role);
        void deleteRole(Guid id);
    }
}
