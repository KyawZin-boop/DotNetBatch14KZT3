using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14KZT3.Shared;

public class BlogService : IBlogService
{
    private readonly SqlConnectionStringBuilder _conntectionBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true,
    };

    public List<BlogModel> GetBlogs()
    {
        SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("select * from tbl_blog with (nolock)", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        List<BlogModel> lst = new List<BlogModel>();
        foreach (DataRow dr in dt.Rows)
        {
            BlogModel item = new BlogModel();
            item.blog_id = dr["blog_id"].ToString()!;
            item.blog_title = dr["blog_title"].ToString()!;
            item.blog_author = dr["blog_author"].ToString()!;
            item.blog_content = dr["blog_content"].ToString()!;

            lst.Add(item);
        }

        return lst;
    }

    public BlogModel GetBlog(string id)
    {
        SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from tbl_blog where blog_id=@blog_id", con);
        cmd.Parameters.AddWithValue("@blog_id", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        if (dt.Rows.Count == 0) return null;

        DataRow dr = dt.Rows[0];

        BlogModel model = new BlogModel();
        model.blog_id = dr["blog_id"].ToString()!;
        model.blog_title = dr["blog_title"].ToString()!;
        model.blog_author = dr["blog_author"].ToString()!;
        model.blog_content = dr["blog_content"].ToString()!;

        return model;
    }

    public BlogResponseModel CreateBlog(BlogModel requestModel)
    {
        string query = $@"INSERT INTO [dbo].[tbl_blog]
                            ([blog_title],[blog_author],[blog_content])
                       Values (@blog_title, @blog_author, @blog_content)";

        SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("blog_title", requestModel.blog_title);
        cmd.Parameters.AddWithValue("blog_author", requestModel.blog_author);
        cmd.Parameters.AddWithValue("blog_content", requestModel.blog_content);
        var result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {
        var item = GetBlog(requestModel.blog_id);
        if (item is null)
        {
            return new BlogResponseModel
            {
                IsSuccess = false,
                Message = "No data found!",
            };
        }

        string conditions = string.Empty;

        if (!string.IsNullOrEmpty(requestModel.blog_title))
        {
            conditions += " [blog_title] = @blog_title, ";
        }
        if (!string.IsNullOrEmpty(requestModel.blog_author))
        {
            conditions += " [blog_author] = @blog_author, ";
        }
        if (!string.IsNullOrEmpty(requestModel.blog_content))
        {
            conditions += " [blog_content] = @blog_content, ";
        }
        if (conditions.Length == 0)
        {
            throw new Exception("Invalid Parameters.");
        }

        conditions = conditions.Substring(0, conditions.Length - 2);

        string query = $@"UPDATE [dbo].[tbl_blog]
                        SET {conditions}
                        WHERE blog_id = @blog_id";

        SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@blog_id", requestModel.blog_id);
        if (!string.IsNullOrEmpty(requestModel.blog_title))
        {
            cmd.Parameters.AddWithValue("@blog_title", requestModel.blog_title);
        }
        if (!string.IsNullOrEmpty(requestModel.blog_author))
        {
            cmd.Parameters.AddWithValue("@blog_author", requestModel.blog_author);
        }
        if (!string.IsNullOrEmpty(requestModel.blog_content))
        {
            cmd.Parameters.AddWithValue("@blog_content", requestModel.blog_content);
        }

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
            string conditions = string.Empty;

            if (!string.IsNullOrEmpty(requestModel.blog_title))
            {
                conditions += " [blog_title] = @blog_title, ";
            }
            if (!string.IsNullOrEmpty(requestModel.blog_author))
            {
                conditions += " [blog_author] = @blog_author, ";
            }
            if (!string.IsNullOrEmpty(requestModel.blog_content))
            {
                conditions += " [blog_content] = @blog_content, ";
            }
            if (conditions.Length == 0)
            {
                throw new Exception("Invalid Parameters.");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            string query = $@"UPDATE [dbo].[tbl_blog]
                        SET {conditions}
                        WHERE blog_id = @blog_id";

            SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@blog_id", requestModel.blog_id);
            if (!string.IsNullOrEmpty(requestModel.blog_title))
            {
                cmd.Parameters.AddWithValue("@blog_title", requestModel.blog_title);
            }
            if (!string.IsNullOrEmpty(requestModel.blog_author))
            {
                cmd.Parameters.AddWithValue("@blog_author", requestModel.blog_author);
            }
            if (!string.IsNullOrEmpty(requestModel.blog_content))
            {
                cmd.Parameters.AddWithValue("@blog_content", requestModel.blog_content);
            }

            int result = cmd.ExecuteNonQuery();

            con.Close();

            string message = result > 0 ? "Update Success." : "Update Fail!";

            model.IsSuccess = result > 0;
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
        SqlConnection con = new SqlConnection(_conntectionBuilder.ConnectionString);
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
