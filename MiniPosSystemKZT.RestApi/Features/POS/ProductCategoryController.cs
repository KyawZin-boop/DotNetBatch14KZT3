using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniPosSystemKZT.RestApi.Features.POS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public ProductCategoryController()
        {
            _service = new CategoryService();
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var model = _service.GetCategories();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(string id)
        {
            var model = _service.GetCategory(id);
            if(model is null)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryModel requestModel)
        {
            var model = _service.CreateCategory(requestModel);
            if (model is null)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpsertCategory(string id, CategoryModel requestModel)
        {
            requestModel.CategoryId = id;
            var model = _service.UpsertCategory(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCategory(string id, CategoryModel requestModel)
        {
            requestModel.CategoryId = id;
            var model = _service.UpdateCategory(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var model = _service.DeleteCategory(id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }
    }
}
