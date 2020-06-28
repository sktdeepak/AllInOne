using AllInOne.API.Interface;
using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class RoleService : IRoleService {
        private readonly IRoleRepository _roleRepository;
        public async Task<Role> GetRoleById(int roleId) {
          return await _roleRepository.GetRoleById(roleId);
        }

        public async Task<List<Role>> GetRoleList() {
            return await _roleRepository.GetRoleList();
        }

        public async Task<int> SaveRole(Role role) {
            return await _roleRepository.SaveRole(role);
        }
    }
}
