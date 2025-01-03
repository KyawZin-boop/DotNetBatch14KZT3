using InventoryManagement.Shared.Services;
using InventoryDB.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        public IActionResult GetOrderDetails(Guid id)
        {
            try
            {
                var orders = _orderService.GetOrderDetails(id);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(Product inputModel)
        {
            try
            {
                var result = _orderService.CreateOrder(inputModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddItemToOrder")]
        //public IActionResult AddItemToOrder(Guid OrderId, Product product)
        //{
        //    try
        //    {
        //        var result = _orderService.AddItemToOrder(OrderId, product);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpDelete("RemoveItemFromOrder")]
        public IActionResult RemoveItemFromOrder(Guid OrderId, Guid ItemId)
        {
            try
            {
                var result = _orderService.RemoveItemFromOrder(OrderId, ItemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
