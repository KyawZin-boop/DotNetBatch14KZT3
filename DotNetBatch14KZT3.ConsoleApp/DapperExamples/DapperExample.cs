using Dapper;
using DotNetBatch14KZT3.ConsoleApp.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT3.ConsoleApp.DapperExamples;

public class DapperExample
{
    private readonly string _connectionString = AppSettings.connBuilder.ConnectionString;

    public void Read()
    {
        using IDbConnection connection = new SqlConnection( _connectionString );

        List<BlogDtos> lst = connection.Query<BlogDtos>("Select * from tbl_blog").ToList();
        foreach (BlogDtos item in lst)
        {
            Console.WriteLine(item.blog_id);
            Console.WriteLine(item.blog_title);
            Console.WriteLine(item.blog_author);
            Console.WriteLine(item.blog_content);
            Console.WriteLine("");
        }
    }

    public void Edit(string id)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        var item = connection.Query<BlogDtos>($"Select * from tbl_blog where blog_id='{id}'").FirstOrDefault();
        if(item is null)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        Console.WriteLine(item.blog_id);
        Console.WriteLine(item.blog_title);
        Console.WriteLine(item.blog_author);
        Console.WriteLine(item.blog_content);
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
                               ,'{content}')";

        using IDbConnection connection = new SqlConnection(_connectionString);
        var result = connection.Execute(query);

        string message = result > 0 ? "Create Success." : "Create Fail!";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string author, string content)
    {
        string query = $@"UPDATE [dbo].[tbl_blog]
                            SET [blog_title] = '{title}'
                                ,[blog_author] = '{author}'
                                ,[blog_content] = '{content}'
                            WHERE blog_id = '{id}'";

        using IDbConnection connection = new SqlConnection(_connectionString);
        var result = connection.Execute(query);

        string message = result > 0 ? "Update Success." : "Update Fail!";
        Console.WriteLine(message);
    }

    public void Delete(string id)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        var result = connection.Execute($"Delete from [dbo].[tbl_blog] where blog_id='{id}'");

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        Console.WriteLine(message);
    }
}
