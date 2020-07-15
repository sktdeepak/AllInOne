using AllInOne.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Interface {
   public interface IAgricultureService {
        Task<List<FieldWorkModel>> GetFieldWorkList();
        Task<int> SaveFieldWork(FieldWorkModel fieldWorkModel);
        Task<FieldWorkModel> GetFieldWorkById(int id);
        Task<int> UpdateFieldWork(FieldWorkModel fieldWorkModel);
        Task<List<FieldWorkModel>> DeleteFieldWork(int id);
        Task<List<FieldWorkModel>> SearchFieldWorkByUserId(int id);

        //Dashboard
        Task<List<DashboardModel>> GetDashboardFieldWorkList();


        //Price Master
        Task<List<PriceModel>> GetPriceList();
        Task<int> SavePrice(PriceModel priceModel);
        Task<PriceModel> GetPriceById(int id);
        Task<int> UpdatePrice(PriceModel priceModel);
        Task<List<PriceModel>> DeletePrice(int id);
    }
}
