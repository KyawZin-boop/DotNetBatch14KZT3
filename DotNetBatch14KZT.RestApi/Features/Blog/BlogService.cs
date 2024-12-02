using System.Data;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KZT.RestApi.Features.Blog;

public class BlogService : IBlogService
{
    private readonly SqlConnectionStringBuilder _connectionBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true,
    };

    public List<BlogModel> GetBlogs()
    {
        SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from tbl_blog", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        List<BlogModel> lst = new List<BlogModel>();
        foreach (DataRow dr in dt.Rows)
        {
            BlogModel item = new BlogModel();
            item.blog_id = dr["blog_id"].ToString();
            item.blog_title = dr["blog_title"].ToString();
            item.blog_author = dr["blog_author"].ToString();
            item.blog_content = dr["blog_content"].ToString();

            lst.Add(item);
        }

        return lst;
    }

    public BlogModel GetBlog(string id)
    {
        SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("select * from tbl_blog where blog_id=@blog_id;", con);
        cmd.Parameters.AddWithValue("@blog_id", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        if (dt.Rows.Count == 0) return null!;

        DataRow row = dt.Rows[0];

        BlogModel item = new BlogModel();
        item.blog_id = row["blog_id"].ToString()!; //use ! to accept null
        item.blog_title = row["blog_title"].ToString()!;
        item.blog_author = row["blog_author"].ToString()!;
        item.blog_content = row["blog_content"].ToString()!;

        return item;
    }

    public BlogResponseModel CreateBlog(BlogModel requestModel)
    {
        string query = $@"INSERT INTO [dbo].[tbl_blog]
                            ([blog_title],[blog_author],[blog_content])
                       Values (@blog_title, @blog_author, @blog_content)";

        SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@blog_title", requestModel.blog_title);
        cmd.Parameters.AddWithValue("@blog_author", requestModel.blog_author);
        cmd.Parameters.AddWithValue("@blog_content", requestModel.blog_content);
        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Saving Success." : "Saving Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {
        var item = GetBlog(requestModel.blog_id!);
        if (item is null)
        {
            return new BlogResponseModel
            {
                IsSuccess = false,
                Message = "No data found."
            };
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

        SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@blog_id", requestModel.blog_id);
        cmd.Parameters.AddWithValue("@blog_title", requestModel.blog_title);
        cmd.Parameters.AddWithValue("@blog_author", requestModel.blog_author);
        cmd.Parameters.AddWithValue("@blog_content", requestModel.blog_content);
        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Update Success." : "Update Fail!";
        BlogResponseModel model = new BlogResponseModel();
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
            SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
            con.Open();

            string query = @"UPDATE [dbo].[tbl_blog]
                                SET [blog_title]='@blog_title',
                                    [blog_author]='@blog_author',
                                    [blog_content]='@blog_content'
                                WHERE blog_id='@blog_id'";

            #region Update Database

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@blog_id", requestModel.blog_id);
            cmd.Parameters.AddWithValue("@blog_title", requestModel.blog_title);
            cmd.Parameters.AddWithValue("@blog_author", requestModel.blog_author);
            cmd.Parameters.AddWithValue("@blog_content", requestModel.blog_content);
            int result = cmd.ExecuteNonQuery();

            con.Close();

            #endregion 

            string message = result > 0 ? "Update Success." : "Update Fail!";

            model.IsSuccess = true;
            model.Message = message;
        }
        else if (item is null)
        {
            model = CreateBlog(requestModel);
        }

        return model;
    }

    public BlogResponseModel DeleteBlog(string id)
    {
        SqlConnection con = new SqlConnection(_connectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("Delete from [dbo].[tbl_blog] where blog_id = @blog_id", con);
        cmd.Parameters.AddWithValue("@blog_id", id);
        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
