namespace DotNetBatch14KZT3.Shared;

public class BlogModel
{
    public string blog_id { get; set; }
    public string blog_title { get; set; }
    public string blog_author { get; set; }
    public string blog_content { get; set; }

}

public class BlogResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}