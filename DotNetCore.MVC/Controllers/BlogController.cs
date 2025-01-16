using DotNetBatch14KZT3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            var lst = await _service.GetBlogs();

            return View("BlogIndex", lst);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog", new BlogModel());
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> SaveBlog(BlogDTO model)
        {
            var response = await _service.CreateBlog(model);
            TempData["isSuccess"] = response.IsSuccess;
            TempData["message"] = response.Message;
            ViewBag.isSuccess = response.Message;

            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(string id)
        {
            var blog = await _service.GetBlog(id);
            return View("EditBlog", blog);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(string id,BlogModel requestModel)
        {
            requestModel.blog_id = id;
            var response = await _service.UpdateBlog(requestModel);
            TempData["isSuccess"] = response.IsSuccess;
            TempData["message"] = response.Message;

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(string id)
        {
            var response = await _service.DeleteBlog(id);
            TempData["isSuccess"] = response.IsSuccess;
            TempData["message"] = response.Message;

            return RedirectToAction("Index");
        }
    }
}
