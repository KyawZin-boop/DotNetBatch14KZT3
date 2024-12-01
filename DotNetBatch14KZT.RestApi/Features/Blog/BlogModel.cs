using Microsoft.Data.SqlClient;

namespace DotNetBatch14KZT.RestApi.Features.Blog
{
    public class BlogModel
    {
        public string? blog_id { get; set; } //use ? to accept null
        public string? blog_title { get; set; }
        public string? blog_author { get; set; }
        public string? blog_content { get; set; }
    }

    public class BlogResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
