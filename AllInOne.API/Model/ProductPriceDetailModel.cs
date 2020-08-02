using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
  public class ProductPriceDetailModel {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Quantity { get; set; }
        public int WeightType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int BuyOrSell { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
