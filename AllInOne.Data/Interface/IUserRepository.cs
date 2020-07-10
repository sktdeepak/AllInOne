using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface {
   public interface IUserRepository {
        Task<UserInfo> GetUserDetails(string username, string password);
        Task<int> SaveUserDetails(UserInfo userInfo);
        Task<List<UserInfo>> UserList();
    }
}
