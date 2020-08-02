using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Implementation {
    public class ProductRepository : IProductRepository {

        private AllInOneContext _allInOneContext;
        public ProductRepository(AllInOneContext allInOneContext) {
            _allInOneContext = allInOneContext;
        }
        public async Task<int> DeleteProductCategoryDetail(int id) {
            ProductCatogery productCategoryDetail = await _allInOneContext.ProductCatogery.FirstOrDefaultAsync(s => s.Id == id);
            _allInOneContext.ProductCatogery.Remove(productCategoryDetail);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductDetail(int id) {
            Product product = await _allInOneContext.Product.FirstOrDefaultAsync(s => s.Id == id);
            _allInOneContext.Product.Remove(product);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductPriceDetail(int id) {
            ProductPriceDetail productCategoryDetail = await _allInOneContext.ProductPriceDetail.FirstOrDefaultAsync(s => s.Id == id);
            _allInOneContext.ProductPriceDetail.Remove(productCategoryDetail);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<ProductCatogery> GetProductCategoryDetail(int id) {
          return  await _allInOneContext.ProductCatogery.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<ProductCatogery>> GetProductCategoryList() {
            return await _allInOneContext.ProductCatogery.ToListAsync();
        }

        public async Task<Product> GetProductDetail(int id) {
            return await _allInOneContext.Product.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Product>> GetProductList() {
            return await _allInOneContext.Product.ToListAsync();
        }

        public async Task<ProductPriceDetail> GetProductPriceDetail(int id) {
           return await _allInOneContext.ProductPriceDetail.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<ProductPriceDetail>> GetProductPriceDetailList() {
            return await _allInOneContext.ProductPriceDetail.Include(c=>c.Product).Include(g=>g.ProductCategory).ToListAsync();
        }

        public async Task<int> SaveProductCategoryDetail(ProductCatogery productCatogery) {
            await _allInOneContext.ProductCatogery.AddAsync(productCatogery);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> SaveProductDetail(Product product) {
            await _allInOneContext.Product.AddAsync(product);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> SaveProductPriceDetail(ProductPriceDetail productPriceDetail) {
            await _allInOneContext.ProductPriceDetail.AddAsync(productPriceDetail);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductCategoryDetail(ProductCatogery productCatogery) {
            _allInOneContext.ProductCatogery.Update(productCatogery);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductDetail(Product produc) {
            _allInOneContext.Product.Update(produc);
            return await _allInOneContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductPriceDetail(ProductPriceDetail productPriceDetail) {
            _allInOneContext.ProductPriceDetail.Update(productPriceDetail);
            return await _allInOneContext.SaveChangesAsync();
        }
    }
}
