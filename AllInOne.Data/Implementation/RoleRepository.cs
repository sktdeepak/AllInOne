using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Implementation {
    public class RoleRepository : IRoleRepository {
        private readonly AllInOneContext _allInOneContext;
        public RoleRepository(AllInOneContext allInOneContext) {
            _allInOneContext = allInOneContext;
        }
        public async Task<Role> GetRoleById(int roleId) {
            return await _allInOneContext.Role.FirstOrDefaultAsync(i => i.Id == roleId);
        }

        public async Task<List<Role>> GetRoleList() {
            return await _allInOneContext.Role.ToListAsync();

        }

        public async Task<int> SaveRole(Role role) {
            await _allInOneContext.Role.AddAsync(role);
            return await _allInOneContext.SaveChangesAsync();

        }
    }
}
