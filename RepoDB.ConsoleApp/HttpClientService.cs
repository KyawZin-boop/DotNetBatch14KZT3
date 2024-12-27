using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RepoDB.Shared;

namespace RepoDB.ConsoleApp
{
    public class HttpClientService
    {
        private readonly HttpClient _client;
        private readonly string endpoint = "https://localhost:7052/api/blogs";

        public HttpClientService()
        {
            _client = new HttpClient();
        }

        public async Task<List<BlogModel>> GetBlogs()
        {
            HttpResponseMessage response = await _client.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();
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
            HttpResponseMessage response = await _client.GetAsync($"{endpoint}/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<BlogModel>(content)!;

            Console.WriteLine(blog.blog_id);
            Console.WriteLine(blog.blog_title);
            Console.WriteLine(blog.blog_author);
            Console.WriteLine(blog.blog_content);

            return blog;
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel model)
        {
            var jsonStr = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(endpoint, stringContent);

            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }

        public async Task<BlogResponseModel> UpdateBlog(BlogModel model)
        {
            var jsonStr = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync(endpoint, stringContent);

            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{endpoint}/{id}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            Console.WriteLine(result.Message);

            return result;
        }
    }
}
