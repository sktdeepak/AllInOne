using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
   public class FieldWorkModel {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int WeightType { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public decimal Weight { get; set; }
        public DateTime Date { get; set; }
        public int PriceId { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal StockAmount { get; set; }
        public decimal TotalStock { get; set; }

    }
}
