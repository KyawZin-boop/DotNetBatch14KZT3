using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Refit;
using RepoDB.Shared;

namespace RepoDB.ConsoleApp
{
    public class RefitService
    {
        private readonly string domain = "https://localhost:7052";
        private readonly IBlogApi _api;

        public RefitService()
        {
            _api = RestService.For<IBlogApi>(domain);
        }

        public async Task<List<BlogModel>> GetBlogs()
        {
            var model = await _api.GetBlogs();

            foreach(var blog in model)
            {
                Console.WriteLine(blog.blog_id);
                Console.WriteLine(blog.blog_title);
                Console.WriteLine(blog.blog_author);
                Console.WriteLine(blog.blog_content);
                Console.WriteLine("");
            }
            return model;
        }

        public async Task<BlogModel> GetBlog(string id)
        {
            var model = await _api.GetBlog(id);

            Console.WriteLine(model.blog_id);
            Console.WriteLine(model.blog_title);
            Console.WriteLine(model.blog_author);
            Console.WriteLine(model.blog_content);

            return model;
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel blogModel)
        {
            var model = await _api.CreateBlog(blogModel);
            Console.WriteLine(model.Message);
            return model;
        }

        public async Task<BlogResponseModel> UpdateBlog(string id, BlogModel blogModel)
        {
            var model = await _api.UpdateBlog(id, blogModel);
            Console.WriteLine(model.Message);
            return model;
        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            var model = await _api.DeleteBlog(id);
            Console.WriteLine(model.Message);
            return model;
        }

        public interface IBlogApi
        {
            [Get("/api/blogs")]
            Task<List<BlogModel>> GetBlogs();

            [Get("/api/blogs/{id}")]
            Task<BlogModel> GetBlog(string id);

            [Post("/api/blogs")]
            Task<BlogResponseModel> CreateBlog(BlogModel requestModel);

            [Put("/api/blogs/{id}")]
            Task<BlogResponseModel> UpdateBlog(string id, BlogModel requestModel);

            [Delete("/api/blogs/{id}")]
            Task<BlogResponseModel> DeleteBlog(string id);
        }

    }
}
