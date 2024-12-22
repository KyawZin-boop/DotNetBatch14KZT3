using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RepoDb;

namespace RepoDB.Shared;

public class RepoDbService
{
    private readonly string _conn = AppSettings._connBuilder.ConnectionString;
    private readonly IDbConnection _dbConnection;

    public RepoDbService()
    {
        _dbConnection = new SqlConnection(_conn);
        RepoDb.SqlServerBootstrap.Initialize();
    }

    public List<BlogModel> GetBlogs()
    {
        List<BlogModel> model = _dbConnection.QueryAll<BlogModel>().ToList();
        return model;
    }

    public BlogModel GetBlog(string id)
    {
        var model = _dbConnection.Query<BlogModel>(id).FirstOrDefault();
        return model;
    }

    public void CreateBlog(BlogModel requestModel)
    {
        var result = _dbConnection.Insert<BlogModel, int>(requestModel);
        Console.WriteLine(result > 0 ? "Create Success." : "Create Fail!");
    }

    public void UpdateBlog(BlogModel requestModel)
    {
        var result = _dbConnection.Update(requestModel);
        Console.WriteLine(result > 0 ? "Upate Success." : "Update Fail!");
    }

    public void DeleteBlog(string id)
    {
        var result = _dbConnection.Delete<BlogModel>(id);
        Console.WriteLine(result > 0 ? "Delete Success." : "Delete Fail!");
    }
}
