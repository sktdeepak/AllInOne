using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Interface {
   public interface IRoleService {
        Task<int> SaveRole(Role role);
        Task<List<Role>> GetRoleList();
        Task<Role> GetRoleById(int roleId);
    }
}
