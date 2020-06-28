using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
