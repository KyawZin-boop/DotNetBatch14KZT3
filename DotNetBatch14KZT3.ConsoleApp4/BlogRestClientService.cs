using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBatch14KZT3.Shared;
using RestSharp;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14KZT3.ConsoleApp4;

public class BlogRestClientService
{
    private readonly string endpoint = "https://localhost:7066/api/blog";
    private readonly RestClient _restClient;

    public BlogRestClientService()
    {
        _restClient = new RestClient();
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);
        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;
    }
    public async Task<BlogResponseModel> GetBlog(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
        RestResponse response = await _restClient.ExecuteAsync(request);
        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(requestModel);
        RestResponse response = await _restClient.ExecuteAsync(request);

        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/{requestModel.blog_id}", Method.Patch);
        request.AddJsonBody(requestModel);
        RestResponse response = await _restClient.ExecuteAsync(request);

        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Delete);
        RestResponse response = await _restClient.ExecuteAsync(request);
        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
    }
}
