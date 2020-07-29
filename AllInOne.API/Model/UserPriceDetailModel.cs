using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
   public class UserPriceDetailModel {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
    }
}
