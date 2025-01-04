using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.Model;
using InventoryManagement.Shared.Services;
using Refit;

namespace InventoryManagementCaller.Console
{
    public class InventoryRefit
    {
        private readonly string domain = "https://localhost:7152";
        private readonly IInventoryApi _api;

        public InventoryRefit()
        {
            _api = RestService.For<IInventoryApi>(domain);
        }

        public async Task<List<Inventory>> GetInventory()
        {
            return await _api.GetInvenotry();
        }

        public async Task<ResponseModel> AddToInventory(Product product)
        {
            return await _api.AddToInentory(product);
        }

        public async Task<ResponseModel> RemoveFromInventory(Guid id)
        {
            return await _api.RemoveFromInventory(id);
        }

        public async Task<ResponseModel> UpdateInventoryItem(Guid id, ProductDTO product)
        {
            return await _api.UpdateInventoryItem(id, product);
        }

        public interface IInventoryApi
        {
            [Get("/api/Inventory")]
            Task<List<Inventory>> GetInvenotry();

            [Post("/api/Inventory/AddToInventory")]
            Task<ResponseModel> AddToInentory(Product product);

            [Delete("/api/Inventory/RemoveFromInventory")]
            Task<ResponseModel> RemoveFromInventory(Guid id);

            [Put("/api/Inventory/UpdateInventoryItem/{id}")]
            Task<ResponseModel> UpdateInventoryItem(Guid id, ProductDTO product);
        }
    }
}
