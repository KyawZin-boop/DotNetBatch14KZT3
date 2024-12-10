using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBatch14KZT3.Shared;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14KZT3.ConsoleApp4;

public class BlogHttpClientService
{
    private readonly string endpoint = "https://localhost:7015/api/blog";
    private readonly HttpClient _httpClient;

    public BlogHttpClientService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;
    }
    public async Task<BlogResponseModel> GetBlog(string id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, stringContent);

        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PatchAsync(endpoint, stringContent);

        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }
}
