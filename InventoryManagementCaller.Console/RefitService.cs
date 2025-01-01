using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.Model;
using Refit;

namespace InventoryManagementCaller.Console
{
    public class RefitService
    {
        private readonly string domain = "https://localhost:7192";
        private readonly IInventoryService _api;

        public RefitService()
        {
            _api = RestService.For<IInventoryService>(domain);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _api.GetProducts();
        }

        public interface IInventoryService
        {
            [Get("/api/Product")]
            Task<List<Product>> GetProducts();

            [Get("/api/Product/{id}")]
            Task<ResponseModel> GetProduct(Guid id);

            [Post("/api/Product/AddProduct")]
            Task<ResponseModel> AddProduct(ProductDTO product);

            [Post("/api/Product/UpdateProduct")]
            Task<ResponseModel> UpdateProduct(Guid id, ProductDTO product);

            [Delete("/api/Product/DeleteProduct")]
            Task<ResponseModel> DeleteProduct(Guid id);
        }
    }
}
