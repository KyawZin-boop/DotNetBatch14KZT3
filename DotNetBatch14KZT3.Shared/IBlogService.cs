namespace DotNetBatch14KZT3.Shared;

public interface IBlogService
{
    BlogResponseModel CreateBlog(BlogDTO requestModel);
    BlogResponseModel DeleteBlog(string id);
    BlogModel GetBlog(string id);
    List<BlogModel> GetBlogs();
    BlogResponseModel UpdateBlog(BlogModel requestModel);
    //BlogResponseModel UpsertBlog(BlogModel requestModel);
}