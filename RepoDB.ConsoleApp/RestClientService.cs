using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RepoDB.Shared;
using RestSharp;

namespace RepoDB.ConsoleApp
{
    public class RestClientService
    {
        private readonly string endpoint = "https://localhost:7066/api/blog";
        private readonly RestClient _client;

        public RestClientService()
        {
            _client = new RestClient();
        }

        public async Task<List<BlogModel>> GetBlogs()
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync(request);
            var content = response.Content;
            var blogs = JsonConvert.DeserializeObject<List<BlogModel>>(content)!;
            foreach (var blog in blogs)
            {
                Console.WriteLine(blog.blog_id);
                Console.WriteLine(blog.blog_title);
                Console.WriteLine(blog.blog_author);
                Console.WriteLine(blog.blog_content);
            }
            return blogs;
        }

        public async Task<BlogModel> GetBlog(string id)
        {
            var request = new RestRequest($"{endpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            var content = response.Content;
            var blog = JsonConvert.DeserializeObject<BlogModel>(content)!;

            Console.WriteLine(blog.blog_id);
            Console.WriteLine(blog.blog_title);
            Console.WriteLine(blog.blog_author);
            Console.WriteLine(blog.blog_content);

            return blog;
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel blogModel)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(blogModel);
            var response = await _client.ExecuteAsync(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }

        public async Task<BlogResponseModel> UpdateBlog(string id, BlogModel blogModel)
        {
            var request = new RestRequest($"{endpoint}/{id}", Method.Put);
            request.AddJsonBody(blogModel);
            var response = await _client.ExecuteAsync(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            var request = new RestRequest($"{endpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }
    }
}
