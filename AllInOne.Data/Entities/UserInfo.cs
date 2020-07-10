using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            UserPersonelInfo = new HashSet<UserPersonelInfo>();
            WeightDetail = new HashSet<WeightDetail>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastAccessedTs { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<UserPersonelInfo> UserPersonelInfo { get; set; }
        public virtual ICollection<WeightDetail> WeightDetail { get; set; }
    }
}
