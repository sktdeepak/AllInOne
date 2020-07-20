using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class UserPriceDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
