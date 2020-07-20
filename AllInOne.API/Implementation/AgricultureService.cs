using AllInOne.API.Interface;
using AllInOne.API.Model;
using AllInOne.Data.Entities;
using AllInOne.Data.Implementation;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class AgricultureService : IAgricultureService {
        private readonly IAgricultureRepository _agricultureRepository;
        private readonly IPriceRepository _priceRepository;
        public AgricultureService(IAgricultureRepository agricultureRepository, IPriceRepository priceRepository) {
            _agricultureRepository = agricultureRepository;
            _priceRepository = priceRepository;
        }

        public async Task<List<FieldWorkModel>> DeleteFieldWork(int id) {
            WeightDetail weightDetail = await _agricultureRepository.GetFieldWorkById(id);
             await _agricultureRepository.DeleteFieldWork(weightDetail);
            return await GetFieldWorkList();
        }

       

        public async Task<FieldWorkModel> GetFieldWorkById(int id) {
            FieldWorkModel fieldWorkModel = new FieldWorkModel();
            WeightDetail weightDetail = await _agricultureRepository.GetFieldWorkById(fieldWorkModel.Id);
            weightDetail.Weight = fieldWorkModel.Weight;
            weightDetail.WeightType = 1;
            weightDetail.UserId = fieldWorkModel.UserId;
            weightDetail.Date =  fieldWorkModel.Date;
            return fieldWorkModel;
        }

        public async Task<List<FieldWorkModel>> GetFieldWorkList() {
            List<FieldWorkModel> fieldWorkModels = new List<FieldWorkModel>();
            List<WeightDetail> weightDetail = await _agricultureRepository.GetFieldWorkList();
            foreach (var item in weightDetail.OrderByDescending(i => i.Date))
            {
                fieldWorkModels.Add(new FieldWorkModel()
                {
                    FullName = item.User.FirstName + " " + item.User.LastName,
                    Weight = item.Weight,
                    WeightType = item.WeightType,
                    Date = item.Date,
                    UserId = item.UserId,
                    Id = item.Id
                });
            }
            return fieldWorkModels;
        }

      

        public async Task<int> SaveFieldWork(FieldWorkModel fieldWorkModel) {
            WeightDetail weightDetail = new WeightDetail();
            weightDetail.CreatedBy = fieldWorkModel.UserId;
            weightDetail.CreatedByTs = DateTime.Now;
            weightDetail.Weight = fieldWorkModel.Weight;
            weightDetail.WeightType = 1;
            weightDetail.UserId = fieldWorkModel.UserId;
            weightDetail.Date = TimeZone.CurrentTimeZone.ToLocalTime(fieldWorkModel.Date);
            weightDetail.PriceId = fieldWorkModel.PriceId;
            return await _agricultureRepository.SaveFieldWork(weightDetail);
        }

       
        public async Task<int> UpdateFieldWork(FieldWorkModel fieldWorkModel) {
            WeightDetail weightDetail = await _agricultureRepository.GetFieldWorkById(fieldWorkModel.Id);
            weightDetail.ModifiedBy = fieldWorkModel.UserId;
            weightDetail.ModifiedByTs = DateTime.Now;
            weightDetail.Weight = fieldWorkModel.Weight;
            weightDetail.WeightType = 1;
            weightDetail.UserId = fieldWorkModel.UserId;
            weightDetail.Date = TimeZone.CurrentTimeZone.ToLocalTime(fieldWorkModel.Date);
            weightDetail.PriceId = fieldWorkModel.PriceId;
            return await _agricultureRepository.UpdateFieldWork(weightDetail);
        }

        public async Task<List<FieldWorkModel>> SearchFieldWorkByUserId(int id) {
            List<FieldWorkModel> fieldWorkModels = new List<FieldWorkModel>();
            List<WeightDetail> weightDetail = await _agricultureRepository.SearchFieldWorkByUserId(id);
            foreach (var item in weightDetail.OrderByDescending(i => i.Date))
            {
                fieldWorkModels.Add(new FieldWorkModel()
                {
                    FullName = item.User.FullName,
                    Weight = item.Weight,
                    WeightType = item.WeightType,
                    Date = item.Date,
                    UserId = item.UserId,
                    Id = item.Id
                });
            }
            return fieldWorkModels;
        }

        public async Task<List<PriceModel>> DeletePrice(int id) {
            Price price = await _agricultureRepository.GetPriceById(id);
            await _agricultureRepository.DeletePrice(price);
            return await GetPriceList();
        }

        public async Task<PriceModel> GetPriceById(int id) {
            PriceModel priceModel = new PriceModel();
            Price price = await _agricultureRepository.GetPriceById(priceModel.Id);
            priceModel.Name = price.Name;
            priceModel.UnitPrice = price.UnitPrice;
            priceModel.Description = price.Description;
            priceModel.Id = price.Id;
            return priceModel;
        }

        public async Task<List<PriceModel>> GetPriceList() {
            List<PriceModel> fieldWorkModels = new List<PriceModel>();
            List<Price> weightDetail = await _agricultureRepository.GetPriceList();
            foreach (var item in weightDetail)
            {
                fieldWorkModels.Add(new PriceModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    UnitPrice=item.UnitPrice,
                    Name = item.Name
                });
            }
            return fieldWorkModels;
        }

        public async Task<int> SavePrice(PriceModel priceModel) {
            Price price = new Price();
            price.CreatedBy = priceModel.UserId;
            price.CreatedByTs = DateTime.Now;
            price.Name = priceModel.Name;
            price.Description = priceModel.Description;
            price.UnitPrice = priceModel.UnitPrice;
            return await _agricultureRepository.SavePrice(price);
        }

        public async Task<int> UpdatePrice(PriceModel priceModel) {
            Price price = await _agricultureRepository.GetPriceById(priceModel.Id);
            price.ModifiedBy = priceModel.UserId;
            price.ModifiedByTs = DateTime.Now;
            price.Name = priceModel.Name;
            price.Description = priceModel.Description;
            price.UnitPrice = priceModel.UnitPrice;
            return await _agricultureRepository.UpdatePrice(price);
        }

        public async Task<List<DashboardModel>> GetDashboardFieldWorkList() {
            List<DashboardModel> dashboardModelList = new List<DashboardModel>();
            List<WeightDetail> weightDetail = await _agricultureRepository.GetFieldWorkList();
            var groupByList= weightDetail.OrderBy(p=>p.User.FirstName).GroupBy(g => g.UserId);
            foreach (var item in groupByList)
            {
                dashboardModelList.Add(new DashboardModel()
                {
                    Name = item.FirstOrDefault().User.FirstName + " " + item.FirstOrDefault().User.LastName,
                    Value = item.Sum(i => i.Weight)
                }) ;
            }
            return dashboardModelList;
        }

        public async Task<List<FieldWorkModel>> SearchFieldWorkByUserId(int id, int viewTypeId) {
            List<FieldWorkModel> fieldWorkModels = new List<FieldWorkModel>();
            List<WeightDetail> weightDetail = await _agricultureRepository.SearchFieldWorkByUserId(id);
            if (viewTypeId == 1)
            {
                foreach (var item in weightDetail.OrderByDescending(i => i.Date))
                {
                    fieldWorkModels.Add(new FieldWorkModel()
                    {
                        FullName = item.User.FullName,
                        Weight = item.Weight,
                        WeightType = item.WeightType,
                        Date = item.Date,
                        UserId = item.UserId,
                        Id = item.Id
                    });
                }
            }
            else
            {
                foreach (var item in weightDetail.GroupBy(i => i.UserId))
                {
                  List<UserPriceDetail> userPriceDetail =  await _priceRepository.GetUserPriceDetailByUserId(item.Key);
                    fieldWorkModels.Add(new FieldWorkModel()
                    {
                        FullName = item.FirstOrDefault().User.FullName,
                        Weight = item.Sum(s => s.Weight),
                        WeightType = item.FirstOrDefault().WeightType,
                        Date = item.FirstOrDefault().Date,
                        UserId = item.Key,
                        CreditAmount = userPriceDetail.Sum(s=>s.CreditAmount) ?? 0,
                        DebitAmount = userPriceDetail.Sum(s => s.DebitAmount) ?? 0,
                        StockAmount = item.Sum(s => s.Weight * s.Price.UnitPrice),
                    }) ;
                }
            }
            return fieldWorkModels;
        }
    }
}
