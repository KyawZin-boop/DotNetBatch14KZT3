using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KZT.RestApi.Features.Blog;


[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly BlogService _blogService;

    public BlogController()
    {
        _blogService = new BlogService();
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var model = _blogService.GetBlogs();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(string id)
    {
        var model = _blogService.GetBlog(id);
        if(model is null)
        {
            return NotFound("No data found.");
        }
        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateBlog([FromBody] BlogModel requestModel)
    {
        var model = _blogService.CreateBlog(requestModel);
        if(model is null)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(string id, BlogModel requestModel)
    {
        requestModel.blog_id = id;

        var model = _blogService.UpdateBlog(requestModel);
        if(!model.IsSuccess)
        {
            return BadRequest(model);
        }

        return Ok(model);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(string id, BlogModel requestModel)
    {
        requestModel.blog_id = id;

        var model = _blogService.UpdateBlog(requestModel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }

        return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(string id)
    {
        var model = _blogService.DeleteBlog(id);
        if (model is null)
        {
            return BadRequest(model);
        }

        return Ok();
    }
}
