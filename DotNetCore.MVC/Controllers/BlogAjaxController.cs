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
    }
}
