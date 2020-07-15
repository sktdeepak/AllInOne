using System;
using System.Collections.Generic;
using System.Text;

namespace AllInOne.Data.Entities {
    public partial class UserInfo {
        public string FullName {
            get {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
