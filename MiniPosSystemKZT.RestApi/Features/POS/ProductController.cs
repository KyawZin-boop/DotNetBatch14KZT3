using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniPosSystemKZT.RestApi.Features.POS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController()
        {
            _service = new ProductService();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _service.GetProducts();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            var model = _service.GetProduct(id);
            if (model is null)
            {
                return NotFound("No data found!");
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel requestModel)
        {
            var model = _service.CreateProduct(requestModel);
            if (model is null)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpsertModel(string id, ProductModel requestModel)
        {
            requestModel.ProductId = id;
            var model = _service.UpsertProduct(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(string id, ProductModel requestModel)
        {
            requestModel.ProductId = id;
            var model = _service.UpdateProduct(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var model = _service.DeleteProduct(id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }
    }
}
