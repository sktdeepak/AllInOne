using AllInOne.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Interface {
   public interface IPriceService {
        Task<List<UserPriceDetailModel>> GetUserPriceDetailList();
        Task<List<UserPriceDetailModel>> SaveUserPriceDetail(UserPriceDetailModel userPriceDetailModel);
        Task<List<UserPriceDetailModel>> UpdateUserPriceDetail(UserPriceDetailModel userPriceDetailModel);
        Task<List<UserPriceDetailModel>> DeleteUserPriceDetail(int id);
        Task<UserPriceDetailModel> GetUserPriceDetail(int id);
    }
}
