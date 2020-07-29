using AllInOne.API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Interface {
   public interface IProductService {
        Task<List<ProductModel>> GetProductList();
        Task<List<ProductModel>> SaveProductDetail(ProductModel productModel);
        Task<List<ProductModel>> UpdateProductDetail(ProductModel productModel);
        Task<List<ProductModel>> DeleteProductDetail(int id);
        Task<ProductModel> GetProductDetail(int id);


        //Product Category
        Task<List<ProductCategoryModel>> GetProductCategoryList();
        Task<List<ProductCategoryModel>> SaveProductCategoryDetail(ProductCategoryModel productCategoryModel);
        Task<List<ProductCategoryModel>> UpdateProductCategoryDetail(ProductCategoryModel productCategoryModel);
        Task<List<ProductCategoryModel>> DeleteProductCategoryDetail(int id);
        Task<ProductCategoryModel> GetProductCategoryDetail(int id);

        //Product Price Detail
        Task<List<ProductPriceDetailModel>> GetProductPriceList();
        Task<List<ProductPriceDetailModel>> SaveProductPriceDetail(ProductPriceDetailModel productPriceDetailModel);
        Task<List<ProductPriceDetailModel>> UpdateProductPriceDetail(ProductPriceDetailModel productPriceDetailModel);
        Task<List<ProductPriceDetailModel>> DeleteProductPriceDetail(int id);
        Task<ProductPriceDetailModel> GetProductPriceDetail(int id);
    }
}
