namespace DotNetBatch14KZT3.Shared;

public interface IBlogService
{
    Task<BlogResponseModel> CreateBlog(BlogDTO requestModel);
    Task<BlogResponseModel> DeleteBlog(string id);
    Task<BlogModel> GetBlog(string id);
    Task<List<BlogModel>> GetBlogs();
    Task<BlogResponseModel> UpdateBlog(BlogModel requestModel);
    //BlogResponseModel UpsertBlog(BlogModel requestModel);
}