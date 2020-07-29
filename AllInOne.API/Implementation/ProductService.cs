using AllInOne.API.Interface;
using AllInOne.API.Model;
using AllInOne.Data.Entities;
using AllInOne.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.API.Implementation {
    public class ProductService : IProductService {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }
        public async Task<List<ProductCategoryModel>> DeleteProductCategoryDetail(int id) {
            await _productRepository.DeleteProductCategoryDetail(id);
            return  await GetProductCategoryList();
        }

        public async Task<List<ProductModel>> DeleteProductDetail(int id) {
            await _productRepository.DeleteProductDetail(id);
            return await GetProductList();
        }

        public async Task<List<ProductPriceDetailModel>> DeleteProductPriceDetail(int id) {
            await _productRepository.DeleteProductCategoryDetail(id);
            return await GetProductPriceList();
        }

        public async Task<ProductCategoryModel> GetProductCategoryDetail(int id) {
            ProductCatogery productCatogery  = await _productRepository.GetProductCategoryDetail(id);
            ProductCategoryModel productCategoryModel = new ProductCategoryModel();
            productCategoryModel.Id = productCatogery.Id;
            productCategoryModel.Name = productCatogery.Name;
            productCategoryModel.Description = productCatogery.Description;
            return productCategoryModel;
        }

        public async Task<List<ProductCategoryModel>> GetProductCategoryList() {
            List<ProductCatogery> productCatogeryList = await _productRepository.GetProductCategoryList();
            List<ProductCategoryModel> productCategoryModel = new List<ProductCategoryModel>();
            foreach (var item in productCatogeryList)
            {
                productCategoryModel.Add(new ProductCategoryModel() { Id = item.Id,Name=item.Name,Description=item.Description});
            }
            return productCategoryModel;
        }

        public async Task<ProductModel> GetProductDetail(int id) {
            Product product = await _productRepository.GetProductDetail(id);
            ProductModel productModel = new ProductModel();
            productModel.Id = product.Id;
            productModel.Name = product.Name;
            productModel.Description = product.Description;
            return productModel;
        }

        public async Task<List<ProductModel>> GetProductList() {
            List<Product> Product = await _productRepository.GetProductList();
            List<ProductModel> productModel = new List<ProductModel>();
            foreach (var item in Product)
            {
                productModel.Add(new ProductModel() { Id = item.Id, Name = item.Name, Description = item.Description });
            }
            return productModel;
        }

        public async Task<ProductPriceDetailModel> GetProductPriceDetail(int id) {
            ProductPriceDetail productPriceDetail = await _productRepository.GetProductPriceDetail(id);
            ProductPriceDetailModel productPriceDetailModel = new ProductPriceDetailModel();

            return productPriceDetailModel;
        }

        public async Task<List<ProductPriceDetailModel>> GetProductPriceList() {
            List<ProductPriceDetail> productPriceDetail = await _productRepository.GetProductPriceDetailList();
            List<ProductPriceDetailModel> productPriceDetailModel = new List<ProductPriceDetailModel>();
            foreach (var item in productPriceDetail)
            {

            }
            return productPriceDetailModel;
        }

        public async Task<List<ProductCategoryModel>> SaveProductCategoryDetail(ProductCategoryModel productCategoryModel) {
            ProductCatogery productCatogery = new ProductCatogery();
            productCatogery.Name = productCategoryModel.Name;
            productCatogery.Description = productCategoryModel.Description;
            productCatogery.CreatedBy = 5;
            productCatogery.CreatedByTs = DateTime.Now;
            await _productRepository.SaveProductCategoryDetail(productCatogery);
            return await GetProductCategoryList();
        }

        public async Task<List<ProductModel>> SaveProductDetail(ProductModel productModel) {
            Product product = new Product();
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.CreatedBy = 5;
            product.CreatedByTs = DateTime.Now;
            await _productRepository.SaveProductDetail(product);
            return await GetProductList();
        }

        public async Task<List<ProductPriceDetailModel>> SaveProductPriceDetail(ProductPriceDetailModel productPriceDetailModel) {
            ProductPriceDetail productPriceDetail = new ProductPriceDetail();
            await _productRepository.SaveProductPriceDetail(productPriceDetail);
            return await GetProductPriceList();
        }

        public async Task<List<ProductCategoryModel>> UpdateProductCategoryDetail(ProductCategoryModel productCategoryModel) {
            ProductCatogery productCatogery = await _productRepository.GetProductCategoryDetail(productCategoryModel.Id);
            productCatogery.Name = productCategoryModel.Name;
            productCatogery.Description = productCategoryModel.Description;
            productCatogery.CreatedBy = 5;
            productCatogery.CreatedByTs = DateTime.Now;
            await _productRepository.UpdateProductCategoryDetail(productCatogery);
            return await GetProductCategoryList();
        }

        public async Task<List<ProductModel>> UpdateProductDetail(ProductModel productModel) {
            Product product = await _productRepository.GetProductDetail(productModel.Id);
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.ModifiedBy = 5;
            product.ModifiedByTs = DateTime.Now;
            await _productRepository.UpdateProductDetail(product);
            return await GetProductList();
        }

        public async Task<List<ProductPriceDetailModel>> UpdateProductPriceDetail(ProductPriceDetailModel productPriceDetailModel) {
            ProductPriceDetail productPriceDetail = new ProductPriceDetail();
            await _productRepository.UpdateProductPriceDetail(productPriceDetail);
            return await GetProductPriceList();
        }

       
    }
}
