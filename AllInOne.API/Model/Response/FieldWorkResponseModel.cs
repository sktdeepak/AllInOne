using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model.Response {
   public class FieldWorkResponseModel {
        public List<FieldWorkModel> DataList { get; set; }
        public string Error { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime LastAccessedTs { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal StockAmount { get; set; }
        public decimal TotalStock { get; set; }
    }
}
