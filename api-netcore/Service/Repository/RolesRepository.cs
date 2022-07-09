using api_netcore.DTO;
using api_netcore.Models;
using api_netcore.Service.Interface;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_netcore.Service.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly d3t2fiuclllna9Context _context;
        private readonly SieveProcessor _sieveProcessor;
        public RolesRepository(d3t2fiuclllna9Context context, SieveProcessor sieveProcessor)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
        }
        public List<DTO.Roles> getAllRoles(string filter, string sort, int page, int pageSize)
        {

            var lst_roles = _context.Roles.Select(x => new DTO.Roles
            {
                Id = x.Id,
                Name = x.Name,
                create_by = x.CreatedBy,
            });

            var sieveModel = new SieveModel
            {
                Sorts = sort,
                Filters = filter,
                Page = page,
                PageSize = pageSize
            };

            lst_roles = _sieveProcessor.Apply(sieveModel, lst_roles);


            return lst_roles.ToList();

        }

        public DTO.Roles getRolesId(Guid id)
        {
            var role = _context.Roles.SingleOrDefault(x => x.Id == id);
            if (role != null)
            {
                return new DTO.Roles
                {
                    Id = role.Id,
                    Name = role.Name,
                    create_by = role.CreatedBy,
                };
            }
            return null;


        }
        public DTO.Roles addRole(DTO.Roles role)
        {
            var _role = new DTO.Roles
            {
                Id = Guid.NewGuid(),
                Name = role.Name,
            };

            _context.Add(_role);
            _context.SaveChanges();
            return new DTO.Roles
            {
                Id = _role.Id,
                Name = _role.Name,
                create_by = _role.create_by
            };

        }

        public void deleteRole(Guid id)
        {
            var role = _context.Roles.SingleOrDefault(x => x.Id == id);
            if (role != null)
            {
                _context.Remove(role);
                _context.SaveChanges();
            }

        }



        public void updateRole(Guid id, DTO.Roles role)
        {
            var _role = _context.Roles.SingleOrDefault(x => x.Id == id);
            if (_role != null)
            {
                _role.Name = role.Name;
                _context.SaveChanges();
            }
        }
    }
}
