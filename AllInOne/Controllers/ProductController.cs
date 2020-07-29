using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Interface;
using AllInOne.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService) {
            _productService = productService;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<List<ProductModel>> Get()
        {
            return await _productService.GetProductList();
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("GetProduct/{id}")]
        public async Task<ProductModel> GetProduct(int id)
        {
            return await _productService.GetProductDetail(id);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<List<ProductModel>> Post([FromBody] ProductModel productModel)
        {
            return await _productService.SaveProductDetail(productModel);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<List<ProductModel>> Put(int id, [FromBody] ProductModel productModel)
        {
            return await _productService.UpdateProductDetail(productModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<List<ProductModel>> Delete(int id)
        {
            return await _productService.DeleteProductDetail(id);
        }

        // GET: api/Product
        [HttpGet]
        [Route("GetProductCategory")]
        public async Task<List<ProductCategoryModel>> GetProductCategory() {
            return await _productService.GetProductCategoryList();
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("ProductCategory/{id}")]
        public async Task<ProductCategoryModel> GetProductCategory(int id) {
            return await _productService.GetProductCategoryDetail(id);
        }

        // POST: api/Product
        [HttpPost]
        [Route("SaveProductCategory")]
        public async Task<List<ProductCategoryModel>> SaveProductCategory([FromBody] ProductCategoryModel productCategoryModel) {
            return await _productService.SaveProductCategoryDetail(productCategoryModel);
        }

        // PUT: api/Product/5
        [HttpPut("UpdateProductCategory/{id}")]
        public async Task<List<ProductCategoryModel>> UpdateProductCategory(int id, [FromBody] ProductCategoryModel productCategoryModel) {
            return await _productService.UpdateProductCategoryDetail(productCategoryModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteProductCategory/{id}")]
        public async Task<List<ProductCategoryModel>> DeleteProductCategory(int id) {
            return await _productService.DeleteProductCategoryDetail(id);
        }

        // GET: api/Product
        [HttpGet]
        [Route("GetProductPrice")]
        public async Task<List<ProductPriceDetailModel>> GetProductPrice() {
            return await _productService.GetProductPriceList();
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("GetProductPrice/{id}")]
        public async Task<ProductPriceDetailModel> GetProductPrice(int id) {
            return await _productService.GetProductPriceDetail(id);
        }

        // POST: api/Product
        [HttpPost]
        [Route("SaveProductPrice")]
        public async Task<List<ProductPriceDetailModel>> SaveProductPrice([FromBody] ProductPriceDetailModel productPriceDetailModel) {
            return await _productService.SaveProductPriceDetail(productPriceDetailModel);
        }

        // PUT: api/Product/5
        [HttpPut("UpdateProductPrice")]
        public async Task<List<ProductPriceDetailModel>> UpdateProductPrice(int id, [FromBody] ProductPriceDetailModel productPriceDetailModel) {
            return await _productService.UpdateProductPriceDetail(productPriceDetailModel);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteProductPrice/{id}")]
        public async Task<List<ProductPriceDetailModel>> DeleteProductPrice(int id) {
            return await _productService.DeleteProductPriceDetail(id);

        }
    }
}
