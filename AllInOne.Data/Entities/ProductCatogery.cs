using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class ProductCatogery
    {
        public ProductCatogery()
        {
            ProductPriceDetail = new HashSet<ProductPriceDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ProductPriceDetail> ProductPriceDetail { get; set; }
    }
}
