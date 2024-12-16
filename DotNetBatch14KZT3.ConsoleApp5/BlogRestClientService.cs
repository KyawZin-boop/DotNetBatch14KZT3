using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace DotNetBatch14KZT3.ConsoleApp5;

public class BlogRestClientService
{
    private readonly string endpoint = "https://localhost:7015/api/blog";
    private readonly RestClient _client;

    public BlogRestClientService()
    {
        _client = new RestClient();
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        RestRequest request = new RestRequest(endpoint);
        RestResponse response = await _client.ExecuteAsync(request);
        var content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> GetBlog(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}");
        RestResponse response = await _client.ExecuteAsync(request);
        var content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;  
    }

    public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest(endpoint);
        request.AddBody(requestModel);
        RestResponse response = await _client.ExecuteAsync(request);

        var content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/{requestModel.blog_id}");
        request.AddBody(requestModel);
        RestResponse response = await _client.ExecuteAsync(request);

        var content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        RestRequest request = new RestRequest(endpoint);
        RestResponse response = await _client.ExecuteAsync(request);
        var content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }
}
