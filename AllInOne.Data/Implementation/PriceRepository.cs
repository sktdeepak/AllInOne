using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Implementation {
    public class PriceRepository : IPriceRepository {
        private AllInOneContext _allInOneContext;
        public PriceRepository(AllInOneContext allInOneContext) {
            _allInOneContext = allInOneContext;
        }
        public async Task<int> DeleteUserPriceDetail(int id) {
            UserPriceDetail userPriceDetail = await _allInOneContext.UserPriceDetail.FirstOrDefaultAsync(s => s.Id == id);
            _allInOneContext.UserPriceDetail.Remove(userPriceDetail);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<UserPriceDetail> GetUserPriceDetail(int id) {
            return await _allInOneContext.UserPriceDetail.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<UserPriceDetail>> GetUserPriceDetailByUserId(int userId) {
            return await _allInOneContext.UserPriceDetail.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<List<UserPriceDetail>> GetUserPriceDetailList() {
            return await _allInOneContext.UserPriceDetail.Include(u=>u.User).ToListAsync();
        }

        public async Task<int> SaveUserPriceDetail(UserPriceDetail userPriceDetail) {
            await _allInOneContext.UserPriceDetail.AddAsync(userPriceDetail);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUserPriceDetail(UserPriceDetail userPriceDetail) {
            _allInOneContext.UserPriceDetail.Update(userPriceDetail);
            return await _allInOneContext.SaveChangesAsync();
        }
    }
}
