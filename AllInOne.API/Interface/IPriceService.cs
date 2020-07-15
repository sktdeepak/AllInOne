using AllInOne.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Interface {
   public interface IPriceService {
        Task<List<UserPriceDetailModel>> GetUserPriceDetailList();
        Task<int> SaveUserPriceDetail(UserPriceDetailModel userPriceDetailModel);
        Task<int> UpdateUserPriceDetail(UserPriceDetailModel userPriceDetailModel);
        Task<int> DeleteUserPriceDetail(int id);
    }
}
