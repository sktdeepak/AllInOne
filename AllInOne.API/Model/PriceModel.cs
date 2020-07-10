using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
   public class PriceModel {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}
