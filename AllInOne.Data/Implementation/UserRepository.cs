using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Implementation {
    public class UserRepository : IUserRepository {
        private readonly AllInOneContext _allInOneContext;
        public UserRepository(AllInOneContext allInOneContext) {
            _allInOneContext = allInOneContext;
        }
        public async Task<UserInfo> GetUserDetails(string username, string password) {
            return await _allInOneContext.UserInfo.FirstOrDefaultAsync(i => i.Username == username && i.Password == password);
        }

        public async Task<int> SaveUserDetails(UserInfo userInfo) {
            await _allInOneContext.UserInfo.AddAsync(userInfo);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<List<UserInfo>> UserList() {
            return await _allInOneContext.UserInfo.ToListAsync();
        }
    }
}
