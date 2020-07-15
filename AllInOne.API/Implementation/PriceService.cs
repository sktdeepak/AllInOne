using AllInOne.API.Interface;
using AllInOne.API.Model;
using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class PriceService : IPriceService {
        public IPriceRepository _priceRepository;

        public PriceService(IPriceRepository priceRepository) {
            _priceRepository = priceRepository;
        }
        public async Task<int> DeleteUserPriceDetail(int id) {
            return await _priceRepository.DeleteUserPriceDetail(id);
        }

        public async Task<List<UserPriceDetailModel>> GetUserPriceDetailList() {
            List<UserPriceDetailModel> userPriceDetailModelList = new List<UserPriceDetailModel>();
            List<UserPriceDetail> userPriceDetailList = await _priceRepository.GetUserPriceDetailList();
            foreach (var item in userPriceDetailList)
            {
                userPriceDetailModelList.Add(new UserPriceDetailModel() { Id = item.Id, UserId = item.UserId, CreditAmount = item.CreditAmount, DebitAmount = item.DebitAmount });
            }
            return userPriceDetailModelList;
        }

        public async Task<int> SaveUserPriceDetail(UserPriceDetailModel userPriceDetailModel) {
            UserPriceDetail userPriceDetail = new UserPriceDetail();
            userPriceDetail.UserId = userPriceDetailModel.UserId;
            userPriceDetail.CreditAmount = userPriceDetailModel.CreditAmount;
            userPriceDetail.DebitAmount = userPriceDetailModel.DebitAmount;
            userPriceDetail.CreatedBy = userPriceDetailModel.UserId;
            userPriceDetail.CreatedByTs = DateTime.Now;
            return await _priceRepository.SaveUserPriceDetail(userPriceDetail);
        }

        public async Task<int> UpdateUserPriceDetail(UserPriceDetailModel userPriceDetailModel) {
            UserPriceDetail userPriceDetail = await _priceRepository.GetUserPriceDetail(userPriceDetailModel.Id);
            userPriceDetail.UserId = userPriceDetailModel.UserId;
            userPriceDetail.CreditAmount = userPriceDetailModel.CreditAmount;
            userPriceDetail.DebitAmount = userPriceDetailModel.DebitAmount;
            userPriceDetail.ModifiedBy = userPriceDetailModel.UserId;
            userPriceDetail.ModifiedByTs = DateTime.Now;
            return await _priceRepository.UpdateUserPriceDetail(userPriceDetail);
        }
    }
}
