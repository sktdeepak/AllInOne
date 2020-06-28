using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface {
   public interface IRoleRepository {
        Task<int> SaveRole(Role role);
        Task<List<Role>> GetRoleList();
        Task<Role> GetRoleById(int roleId);
    }
}
