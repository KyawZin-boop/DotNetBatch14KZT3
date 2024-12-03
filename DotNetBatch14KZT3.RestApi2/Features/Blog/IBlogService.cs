
namespace DotNetBatch14KZT3.RestApi2.Features.Blog
{
    public interface IBlogService
    {
        BlogResponseModel CreateBlog(BlogModel requestModel);
        BlogResponseModel Delete(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        BlogResponseModel Update(BlogModel requestModel);
        BlogResponseModel Upsert(BlogModel requestModel);
    }
}