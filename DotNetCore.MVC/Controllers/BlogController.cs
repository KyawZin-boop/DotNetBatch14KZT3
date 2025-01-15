using DotNetBatch14KZT3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;

        public BlogController()
        {
            _service = new BlogEFCoreService();
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            var lst = _service.GetBlogs();

            return View("BlogIndex", lst);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog", new BlogModel());
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult SaveBlog(BlogDTO model)
        {
            var response = _service.CreateBlog(model);
            ViewBag.isSuccess = response.IsSuccess;
            ViewBag.message = response.Message;

            return View("CreateBlog");
        }
    }
}
