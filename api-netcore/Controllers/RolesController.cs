using api_netcore.DTO;
using api_netcore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult GetAll(string filter, string sort, int page, int pageSize)
        {
            if (page == 0 || pageSize == 0)
            {
                page = 1;
                pageSize = 10;
            }
            try
            {
                var result = new { success = true, data = _rolesRepository.getAllRoles(filter, sort, page, pageSize), page = page, pageSize = pageSize };
                return Ok(result);
            }
            catch
            {
                //var result = new { success = false };
                return BadRequest();
            }

        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public IActionResult GetRoleById(Guid id)
        {
            try
            {

                var role = new { success = true, message = "Thao tác thành công", data = _rolesRepository.getRolesId(id) };
                if (role != null)
                {
                    return Ok(role);
                }
                else
                {
                    var result = new { success = false, message = "Không tìm thấy dữ liệu" };
                    return NotFound(result);
                }

            }
            catch
            {
                var result = new { success = false, message = "Lỗi thao tác" };
                return BadRequest(result);
            }
        }

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult postRole([Bind("Name")] RolesDTO role)
        {
            try
            {
                var result = new { success = true, message = "Thao tác thành công", data = _rolesRepository.addRole(role) };
                return Ok(result);

            }
            catch (Exception ex)
            {
                var result = new { success = false, message = "Thao tác thất bại" };
                return BadRequest(result);
            }
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRole(Guid id, RolesDTO role)
        {
            try
            {
                _rolesRepository.updateRole(id, role);
                var result = new { success = true, message = "Thao tác thành công" };
                return Ok(result);


            }
            catch
            {
                var result = new { success = false, message = "Thao tác thất bại" };
                return BadRequest(result);
            }
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _rolesRepository.deleteRole(id);
                var result = new { success = true, message = "Thao tác thành công" };
                return Ok(result);


            }
            catch
            {
                var result = new { success = false, message = "Thao tác thất bại" };
                return BadRequest(result);
            }
        }
    }
}
