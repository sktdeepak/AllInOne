using System;
using System.Collections.Generic;

namespace AllInOne.Data.Entities
{
    public partial class ProductPriceDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Quantity { get; set; }
        public int WeightType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int? BuyOrSell { get; set; }
        public DateTime CreatedByTs { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedByTs { get; set; }
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductCatogery ProductCategory { get; set; }
    }
}
