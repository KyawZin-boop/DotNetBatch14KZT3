using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.Model;
using Refit;

namespace InventoryManagementCaller.Console
{
    public class OrderRefit
    {
        private readonly string domain = "https://localhost:7152";
        private readonly IOrderApi _api;

        public OrderRefit()
        {
            _api = RestService.For<IOrderApi>(domain);
        }

        public async Task<Order> GetOrderDetails(Guid id)
        {
            return await _api.GetOrderDetails(id);
        }

        public async Task<ResponseModel> AddItemToOrder(Product product)
        {
            return await _api.AddItemToOrder(product);
        }

        public async Task<ResponseModel> RemoveItemFromOrder(Guid id, Guid itemId)
        {
            return await _api.RemoveItemFromOrder(id, itemId);
        }

        public async Task<ResponseModel> CreateOrder(Product product)
        {
            var result = await _api.CreateOrder(product);
            return result;
        }

        public interface IOrderApi
        {
            [Get("/api/Order")]
            Task<Order> GetOrderDetails(Guid id);

            [Post("/api/Order/AddItemToOrder")]
            Task<ResponseModel> AddItemToOrder(Product product);

            [Delete("/api/Order/RemoveItemFromOrder")]
            Task<ResponseModel> RemoveItemFromOrder(Guid id, Guid itemId);

            [Post("/api/Order/CreateOrder")]
            Task<ResponseModel> CreateOrder(Product product);
        }
    }
}
