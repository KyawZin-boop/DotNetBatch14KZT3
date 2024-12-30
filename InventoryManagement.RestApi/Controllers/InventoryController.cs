using InventoryManagement.Shared.Services;
using InventoryManagementDB.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController()
        {
            _inventoryService = new InventoryService();
        }

        [HttpGet]
        public IActionResult ListInventory()
        {
            try
            {
                var result = _inventoryService.GetInventory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddToInventory")]
        public IActionResult AddToInventory(Product inputModel)
        {
            try
            {
                var result = _inventoryService.AddToInventory(inputModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("RemoveFromInventory")]
        public IActionResult RemoveFromInventory(Guid proudctID)
        {
            try
            {
                var result = _inventoryService.RemoveFromInventory(proudctID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateInventoryItem/{id}")]
        public IActionResult UpdateInventoryItem(Guid id, ProductDTO inputModel)
        {
            try
            {
                var result = _inventoryService.UpdateInventoryItem(id, inputModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
