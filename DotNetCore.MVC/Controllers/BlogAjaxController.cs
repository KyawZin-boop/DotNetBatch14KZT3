using DotNetBatch14KZT3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.MVC.Controllers
{

    public class BlogAjaxController : Controller
    {
        private readonly IBlogService _service;

        public BlogAjaxController(IBlogService service)
        {
            _service = service;
        }

        [ActionName("Index")]
        public IActionResult BlogAjaxIndex()
        {
            return View("BlogAjaxIndex");
        }

        [HttpGet]
        [ActionName("GetBlogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _service.GetBlogs();

            return Json(blogs);
        }

        [ActionName("CreateAjax")]
        public async Task<IActionResult> CreateBlog()
        {
            return View("CreateBlogAjax", new BlogModel());
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> SaveBlog(BlogDTO requestModel)
        {
            var response = await _service.CreateBlog(requestModel);

            return Json(response.Message);
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(string id)
        {
            var blog = await _service.GetBlog(id);

            return View("EditBlogAjax", blog);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(BlogModel model)
        {
            var response = await _service.UpdateBlog(model);

            return Json(response);
        }

        [ActionName("DeleteBlogAjax")]
        public async Task<IActionResult> DeleteBlog(string id)
        {
            var response = await _service.DeleteBlog(id);

            return Json(response.Message);
        }
    }
}
