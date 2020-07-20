using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface {
   public interface IPriceRepository {
        Task<List<UserPriceDetail>> GetUserPriceDetailList();
        Task<UserPriceDetail> GetUserPriceDetail(int id);
        Task<int> SaveUserPriceDetail(UserPriceDetail userPriceDetail);
        Task<int> UpdateUserPriceDetail(UserPriceDetail userPriceDetail);
        Task<int> DeleteUserPriceDetail(int id);

        Task<List<UserPriceDetail>> GetUserPriceDetailByUserId(int userId);
    }
}
