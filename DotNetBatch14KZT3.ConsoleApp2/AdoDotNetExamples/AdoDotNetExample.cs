using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT3.ConsoleApp2.AdoDotNetExamples;

public class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder _connBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "test_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true,
    };

    public void Read()
    {
        SqlConnection con = new SqlConnection(_connBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from tbl_blog", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("id = " + dr["blog_id"]);
            Console.WriteLine("title = " + dr["blog_title"]);
            Console.WriteLine("author = " + dr["blog_author"]);
            Console.WriteLine("content = " + dr["blog_content"]);
            Console.WriteLine("");
        }
    }

    public void Edit(string id)
    {
        SqlConnection con = new SqlConnection(_connBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand($"Select * from tbl_blog where blog_id='{id}'", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        if(dt.Rows.Count == 0)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        DataRow dr = dt.Rows[0];

        Console.WriteLine("id = " + dr["blog_id"]);
        Console.WriteLine("title = " + dr["blog_title"]);
        Console.WriteLine("author = " + dr["blog_author"]);
        Console.WriteLine("content = " + dr["blog_content"]);
        Console.WriteLine("");
    }

    public void Create(string title, string author, string content)
    {
        string query = @$"INSERT INTO [dbo].[tbl_blog]
                               ([blog_title]
                               ,[blog_author]
                               ,[blog_content])
                         VALUES
                               ('{title}'
                               ,'{author}'
                               ,'{content}')"; ;

        SqlConnection con = new SqlConnection(_connBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        var result = cmd.ExecuteNonQuery();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string author, string content)
    {
        string query = @$"Update [dbo].[tbl_blog] 
                                SET [blog_title]='updatedTitle',
                                    [blog_author]='updatedAuthor',
                                    [blog_content]='updatedContent'
                                where blog_id='{id}'"; ;

        SqlConnection con = new SqlConnection(_connBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        var result = cmd.ExecuteNonQuery();

        string message = result > 0 ? "Update Success." : "Update Fail!";
        Console.WriteLine(message);
    }

    public void Delete(string id)
    {
        SqlConnection con = new SqlConnection( _connBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand($"Delete from [dbo].[tbl_blog] where blog_id='{id}'", con);
        var result = cmd.ExecuteNonQuery();

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        Console.WriteLine(message);
    }
}
