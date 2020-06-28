using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class UserPersonelInfo
    {
        public int Id { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirthTs { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }
        public int UserInfoId { get; set; }
        public DateTime? CreatedByTs { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
