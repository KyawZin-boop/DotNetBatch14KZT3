using InventoryManagement.Shared.Services;
using InventoryManagementDB.shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController()
    {
        _productService = new ProductService();
    }

    [HttpGet("GetProducts")]
    public IActionResult GetProducts()
    {
        try
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(Guid id)
    {
        try
        {
            var product = _productService.GetProduct(id);
            if(product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("AddProduct")]
    public IActionResult AddProduct(ProductDTO inputModel)
    {
        try
        {
            var result = _productService.AddProduct(inputModel);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("UpdateProduct")]
    public IActionResult UpdateProduct(Guid id, ProductDTO inputModel)
    {
        try
        {
            var result = _productService.UpdateProduct(id, inputModel);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeleteProduct")]
    public IActionResult DeleteProduct(Guid id)
    {
        try
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
