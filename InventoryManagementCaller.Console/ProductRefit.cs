using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.Model;
using Refit;

namespace InventoryManagementCaller.Console
{
    public class ProductRefit
    {
        private readonly string domain = "https://localhost:7152";
        private readonly IProductApi _api;

        public ProductRefit()
        {
            _api = RestService.For<IProductApi>(domain);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _api.GetProducts();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _api.GetProduct(id);
        }

        public async Task<ResponseModel> AddProduct(ProductDTO product)
        {
            return await _api.AddProduct(product);
        }

        public async Task<ResponseModel> UpdateProduct(Guid id, ProductDTO product)
        {
            var result = await _api.UpdateProduct(id, product);
            return result;
        }

        public interface IProductApi
        {
            [Get("/api/Product")]
            Task<List<Product>> GetProducts();

            [Get("/api/Product/{id}")]
            Task<Product> GetProduct(Guid id);

            [Post("/api/Product/AddProduct")]
            Task<ResponseModel> AddProduct(ProductDTO product);

            [Patch("/api/Product/UpdateProduct")]
            Task<ResponseModel> UpdateProduct(Guid id, ProductDTO product);

            [Delete("/api/Product/DeleteProduct")]
            Task<ResponseModel> DeleteProduct(Guid id);
        }
    }
}
