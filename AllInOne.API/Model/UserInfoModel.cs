using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
   public class UserInfoModel {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
