using AllInOne.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Data.Interface {
    public interface IProductRepository {
        //Product
        Task<List<Product>> GetProductList();
        Task<Product> GetProductDetail(int id);
        Task<int> SaveProductDetail(Product product);
        Task<int> UpdateProductDetail(Product product);
        Task<int> DeleteProductDetail(int id);

        //Product Category
        Task<List<ProductCatogery>> GetProductCategoryList();
        Task<ProductCatogery> GetProductCategoryDetail(int id);
        Task<int> SaveProductCategoryDetail(ProductCatogery productCatogery);
        Task<int> UpdateProductCategoryDetail(ProductCatogery productCatogery);
        Task<int> DeleteProductCategoryDetail(int id);

        //Product Price Detail
        Task<List<ProductPriceDetail>> GetProductPriceDetailList();
        Task<ProductPriceDetail> GetProductPriceDetail(int id);
        Task<int> SaveProductPriceDetail(ProductPriceDetail productPriceDetail);
        Task<int> UpdateProductPriceDetail(ProductPriceDetail productPriceDetail);
        Task<int> DeleteProductPriceDetail(int id);
    }
}
