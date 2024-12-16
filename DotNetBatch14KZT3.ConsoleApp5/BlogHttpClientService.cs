using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14KZT3.ConsoleApp5;

public class BlogHttpClientService
{
    string endpoint = "https://localhost:7066/api/blog";
    private readonly HttpClient _client = new HttpClient();

    public async Task<BlogListResponseModel> GetBlogs()
    {
        HttpResponseMessage response = await _client.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> GetBlog(string id)
    {
        HttpResponseMessage response = await _client.GetAsync($"{endpoint}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _client.PostAsync(endpoint, stringContent);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _client.PatchAsync($"{endpoint}/{requestModel.blog_id}", stringContent);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        HttpResponseMessage response = await _client.DeleteAsync($"{endpoint}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }
}
