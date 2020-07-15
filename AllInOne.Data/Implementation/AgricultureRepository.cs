using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Implementation {
    public class AgricultureRepository : IAgricultureRepository {
        private readonly AllInOneContext _allInOneContext;
        public AgricultureRepository(AllInOneContext allInOneContext) {
            _allInOneContext = allInOneContext;
        }

        public async Task<int> DeleteFieldWork(WeightDetail fieldWorkModel) {
            _allInOneContext.WeightDetail.Remove(fieldWorkModel);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> DeletePrice(Price price) {
            _allInOneContext.Price.Remove(price);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<WeightDetail> GetFieldWorkById(int id) {
            return await _allInOneContext.WeightDetail.Include(i => i.User).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<WeightDetail>> GetFieldWorkList() {
            return await _allInOneContext.WeightDetail.Include(i => i.User).ToListAsync();
        }

        public async Task<Price> GetPriceById(int id) {
            return await _allInOneContext.Price.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Price>> GetPriceList() {
            return await _allInOneContext.Price.ToListAsync();
        }

        public async Task<int> SaveFieldWork(WeightDetail fieldWorkModel) {
            await _allInOneContext.WeightDetail.AddAsync(fieldWorkModel);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<List<WeightDetail>> SearchFieldWorkByUserId(int userId) {
            return await _allInOneContext.WeightDetail.Include(i => i.User).Where(w=>w.UserId == userId).ToListAsync();
        }

        public async Task<int> SavePrice(Price price) {
            await _allInOneContext.Price.AddAsync(price);
            return await _allInOneContext.SaveChangesAsync();
        }

       

        public async Task<int> UpdateFieldWork(WeightDetail fieldWorkModel) {
            _allInOneContext.WeightDetail.Update(fieldWorkModel);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePrice(Price price) {
            _allInOneContext.Price.Update(price);
            return await _allInOneContext.SaveChangesAsync();
        }
    }
}
