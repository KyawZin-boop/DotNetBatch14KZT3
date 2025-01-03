﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace DotNetBatch14KZT3.ConsoleApp5;

public class BlogRefitService
{
    private readonly string domain = "https://localhost:7015";
    private readonly IBlogApi _api;

    public BlogRefitService()
    {
        _api = RestService.For<IBlogApi>(domain);
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        var model = await _api.GetBlogs();
        return model;
    }

    public async Task<BlogResponseModel> GetBlog(string id)
    {
        var model = await _api.GetBlog(id);
        return model;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
    {
        var model = await _api.CreateBlog(requestModel);
        return model;
    }

    public async Task<BlogResponseModel> UpdateBlog(string id, BlogModel requestModel)
    {
        var model = await _api.UpdateBlog(id, requestModel);
        return model;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        var model = await _api.DeleteBlog(id);
        return model;
    }

    public interface IBlogApi
    {
        [Get("/api/blog")]
        Task<BlogListResponseModel> GetBlogs();

        [Get("/api/blog/{id}")]
        Task<BlogResponseModel> GetBlog(string id);

        [Post("/api/blog")]
        Task<BlogResponseModel> CreateBlog(BlogModel requestModel);

        [Patch("/api/blog/{id}")]
        Task<BlogResponseModel> UpdateBlog(string id, BlogModel requestModel);

        [Delete("/api/blog/{id}")]
        Task<BlogResponseModel> DeleteBlog(string id);
    }
}
