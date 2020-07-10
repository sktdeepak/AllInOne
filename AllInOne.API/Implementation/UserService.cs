using AllInOne.API.Interface;
using AllInOne.API.Model;
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
            userInfo.CreatedBy = 1;
            userInfo.CreatedByTs = DateTime.Now;
            return await _userRepository.SaveUserDetails(userInfo);
        }

        public async Task<List<UserInfoModel>> UserList() {
          List<UserInfo> userInfo =  await _userRepository.UserList();
            List<UserInfoModel> userInfoModelList = new List<UserInfoModel>();
            foreach (var item in userInfo)
            {
                UserInfoModel userInfoModel = new UserInfoModel();
                userInfoModel.Email = item.Email;
                userInfoModel.Username = item.Username;
                userInfoModel.Firstname = item.FirstName;
                userInfoModel.LastName = item.LastName;
                userInfoModel.Id = item.Id;
                //userInfoModel.DateOfBirth = item.DateOfBirth;
                //userInfoModel.
                userInfoModelList.Add(userInfoModel);
            }

            return userInfoModelList;
        }

    }
}
