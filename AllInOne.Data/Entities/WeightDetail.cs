﻿using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class WeightDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public decimal Weight { get; set; }
        public int WeightType { get; set; }
        public decimal UnitPrice { get; set; }
        public int PriceId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual Price Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual UserInfo User { get; set; }
    }
}
