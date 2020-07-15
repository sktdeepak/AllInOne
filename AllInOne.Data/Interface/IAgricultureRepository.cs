using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface {
   public interface IAgricultureRepository {
        Task<List<WeightDetail>> GetFieldWorkList();
        Task<int> SaveFieldWork(WeightDetail fieldWorkModel);
        Task<WeightDetail> GetFieldWorkById(int id);
        Task<int> UpdateFieldWork(WeightDetail fieldWorkModel);
        Task<int> DeleteFieldWork(WeightDetail fieldWorkModel);
        Task<List<WeightDetail>> SearchFieldWorkByUserId(int userId);


        //Price Master
        Task<List<Price>> GetPriceList();
        Task<int> SavePrice(Price price);
        Task<Price> GetPriceById(int id);
        Task<int> UpdatePrice(Price price);
        Task<int> DeletePrice(Price price);
    }
}
