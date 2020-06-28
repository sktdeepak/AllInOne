using AllInOne.API.Interface;
using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public async Task<UserInfo> GetUserDetails(string username, string password) {
            return await _userRepository.GetUserDetails(username, password);
        }

        public async Task<int> SaveUserDetails(UserInfo userInfo) {
            return await _userRepository.SaveUserDetails(userInfo);
        }
    }
}
