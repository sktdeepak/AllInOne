using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Interface;
using AllInOne.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetSelectedRoleItem/{Id}")]
        public async Task<Role> GetSelectedRoleItem(int roleId) {
            return await _roleService.GetRoleById(roleId);
        }

        [HttpGet]
        [Route("GetRoleList")]
        public async Task<List<Role>> GetRoleList() {
            return await _roleService.GetRoleList();
        }

        [HttpPost]
        [Route("SaveRole")]
        public async Task<int> SaveRole([FromBody]Role role) {
            return await _roleService.SaveRole(role);
        }
    }
}