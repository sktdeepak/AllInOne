using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.API.Model {
   public class SearchModel {
        public int UserId { get; set; }
        public int ViewType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
