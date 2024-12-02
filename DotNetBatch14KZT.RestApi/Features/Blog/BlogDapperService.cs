using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KZT.RestApi.Features.Blog;

public class BlogDapperService : IBlogService
{
    private readonly SqlConnectionStringBuilder _connBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true
    };

    public List<BlogModel> GetBlogs()
    {
        using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);
        List<BlogModel> lst = db.Query<BlogModel>("select * from tbl_blog with (nolock)").ToList();
        return lst;
    }

    public BlogModel GetBlog(string id)
    {
        string query = "Select * from tbl_blog with (nolock) where blog_id='@blog_id'";
        using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);

        var item = db.QueryFirstOrDefault<BlogModel>(query, new BlogModel
        {
            blog_id = id
        });
        return item!;  
    }

    public BlogResponseModel CreateBlog(BlogModel requestModel)
    {
        string query = $@"INSERT INTO [dbo].[tbl_blog]
                            ([blog_title],[blog_author],[blog_content])
                       Values (@blog_title, @blog_author, @blog_content)";

        using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);
        int result = db.Execute(query, requestModel);

        string message = result > 0 ? "Create Success." : "Create Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.Message = message;
        model.IsSuccess = result > 0;

        return model;
    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {
        BlogResponseModel model = new BlogResponseModel();

        var item = GetBlog(requestModel.blog_id!);
        if (item is null)
        {
            model.IsSuccess = false;
            model.Message = "No data found.";
            return model;
        }

        if (string.IsNullOrEmpty(requestModel.blog_title))
        {
            requestModel.blog_title = item.blog_title;
        }
        if (string.IsNullOrEmpty(requestModel.blog_author))
        {
            requestModel.blog_author = item.blog_author;
        }
        if (string.IsNullOrEmpty(requestModel.blog_content))
        {
            requestModel.blog_content = item.blog_content;
        }

        string query = @"UPDATE [dbo].[tbl_blog]
                        SET [blog_title] = @blog_title,
                            [blog_author] = @blog_author,
                            [blog_content] = @blog_content
                        WHERE blog_id = @blog_id";

        using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);
        var result = db.Execute(query, requestModel);

        string message = result > 0 ? "Update Success." : "Update Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public BlogResponseModel UpsertBlog(BlogModel requestModel)
    {
        BlogResponseModel model = new BlogResponseModel();

        var item = GetBlog(requestModel.blog_id!);
        if (item is not null)
        {
            string query = @"UPDATE [dbo].[tbl_blog]
                               SET [blog_title] = @blog_title
                                  ,[blog_author] = @blog_author
                                  ,[blog_content] = @blog_content
                             WHERE blog_id = @blog_id";

            using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);
            var result = db.Execute(query, requestModel);

            string message = result > 0 ? "Update Success." : "Update Fail!";
            model.IsSuccess = result > 0;
            model.Message = message;
        }
        else if(item is null)
        {
            model = CreateBlog(requestModel);
        }

        return model;
    }

    public BlogResponseModel DeleteBlog(string id)
    {
        string query = "Delete from [dbo].[tbl_blog] where blog_id='@blog_id'";
        using IDbConnection db = new SqlConnection(_connBuilder.ConnectionString);
        var result = db.Execute(query, new BlogModel
        {
            blog_id = id
        });

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }


}
