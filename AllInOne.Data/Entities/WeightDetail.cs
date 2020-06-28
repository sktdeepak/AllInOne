using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class WeightDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Weight { get; set; }
        public int WeightType { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual UserInfo IdNavigation { get; set; }
    }
}
