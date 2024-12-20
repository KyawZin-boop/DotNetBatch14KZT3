using DotNetBatch14KZT3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KZT.RestApi3.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogEFCoreService();
        }
 
        [HttpGet]
        public IActionResult GetBlogs()
        {
            try
            {
                var lst = _blogService.GetBlogs();
                BlogListResponseModel model = new BlogListResponseModel()
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = lst,
                };
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BlogListResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(string id)
        {
            try
            {
                var model = _blogService.GetBlog(id);
                if (model is null)
                {
                    return NotFound(new BlogListResponseModel
                    {
                        Message = "No data found!"
                    });
                }

                return Ok(new BlogResponseModel()
                {
                    IsSuccess = true,
                    Message = "Success.",
                    Data = model,
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogModel requestModel)
        {
            try
            {
                var model = _blogService.CreateBlog(requestModel);
                if (model is null)
                {
                    return BadRequest(model);
                }
                return Ok(model);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpsertBlog(string id, BlogModel requestModel)
        {
            try
            {
                requestModel.blog_id = id;
                var model = _blogService.UpsertBlog(requestModel);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }

                return Ok(model);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            try
            {
                requestModel.blog_id = id;
                var model = _blogService.UpdateBlog(requestModel);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }

                return Ok(model);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(string id)
        {
            try
            {
                var model = _blogService.DeleteBlog(id);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString()
                });
            }
        }
    }
}
