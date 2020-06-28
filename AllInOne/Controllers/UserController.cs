using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Interface;
using AllInOne.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        [Route("Login/{username}/{password}")]
        public async Task<UserInfo> Login(string username, string password) {
            return await _userService.GetUserDetails(username, password);
        }

        [HttpPost]
        [Route("SubmitUser")]
        public async Task<int> SubmitUser([FromBody]UserInfo userInfo) {
            return await _userService.SaveUserDetails(userInfo);
        }
    }
}