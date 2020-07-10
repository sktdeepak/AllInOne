using AllInOne.API.Interface;
using AllInOne.API.Model;
using AllInOne.Data.Entities;
using AllInOne.Data.Implementation;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class AgricultureService : IAgricultureService {
        private readonly IAgricultureRepository _agricultureRepository;
        public AgricultureService(IAgricultureRepository agricultureRepository) {
            _agricultureRepository = agricultureRepository;
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
            weightDetail.Date = fieldWorkModel.Date;
            return fieldWorkModel;
        }

        public async Task<List<FieldWorkModel>> GetFieldWorkList() {
            List<FieldWorkModel> fieldWorkModels = new List<FieldWorkModel>();
            List<WeightDetail> weightDetail = await _agricultureRepository.GetFieldWorkList();
            foreach (var item in weightDetail)
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
            weightDetail.Date = fieldWorkModel.Date;
            return await _agricultureRepository.SaveFieldWork(weightDetail);
        }

       
        public async Task<int> UpdateFieldWork(FieldWorkModel fieldWorkModel) {
            WeightDetail weightDetail = await _agricultureRepository.GetFieldWorkById(fieldWorkModel.Id);
            weightDetail.ModifiedBy = fieldWorkModel.UserId;
            weightDetail.ModifiedByTs = DateTime.Now;
            weightDetail.Weight = fieldWorkModel.Weight;
            weightDetail.WeightType = 1;
            weightDetail.UserId = fieldWorkModel.UserId;
            weightDetail.Date = fieldWorkModel.Date;
            return await _agricultureRepository.UpdateFieldWork(weightDetail);
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
    }
}
