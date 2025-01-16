using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KZT3.Shared;

public class BlogEFCoreService : IBlogService
{
    private readonly AppDbContext _db;

    public BlogEFCoreService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogDTO requestModel)
    {
        var blog = new BlogModel
        {
            blog_id = Guid.NewGuid().ToString(),
            blog_title = requestModel.blog_title,
            blog_author = requestModel.blog_author,
            blog_content = requestModel.blog_content,
        };
        await _db.Blogs.AddAsync(blog);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public async Task<BlogResponseModel> DeleteBlog(string id)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.blog_id == id);
        if (item is null)
        {
            return new BlogResponseModel
            {
                IsSuccess = false,
                Message = "No data found."
            };
        }

        _db.Entry(item).State = EntityState.Deleted;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public async Task<BlogModel> GetBlog(string id)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.blog_id == id);
        return item!;
    }

    public async Task<List<BlogModel>> GetBlogs()
    {
        List<BlogModel> lst = await _db.Blogs.AsNoTracking().ToListAsync();
        return lst;
    }

    public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
    {
        var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.blog_id == requestModel.blog_id);
        if (item is null)
        {
            return new BlogResponseModel
            {
                IsSuccess = false,
                Message = "No data found!",
            };
        }

        if (!string.IsNullOrEmpty(requestModel.blog_title))
        {
            item.blog_title = requestModel.blog_title;
        }
        if (!string.IsNullOrEmpty(requestModel.blog_author))
        {
            item.blog_author = requestModel.blog_author;
        }
        if (!string.IsNullOrEmpty(requestModel.blog_content))
        {
            item.blog_content = requestModel.blog_content;
        }

        _db.Entry(item).State = EntityState.Modified;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Update Success." : "Update Fail!";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    //public BlogResponseModel UpsertBlog(BlogModel requestModel)
    //{
    //    BlogResponseModel model = new BlogResponseModel();

    //    var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.blog_id == requestModel.blog_id);
    //    if (item is not null)
    //    {
    //        if (!string.IsNullOrEmpty(requestModel.blog_title))
    //        {
    //            item.blog_title = requestModel.blog_title;
    //        }
    //        if (!string.IsNullOrEmpty(requestModel.blog_author))
    //        {
    //            item.blog_author = requestModel.blog_author;
    //        }
    //        if (!string.IsNullOrEmpty(requestModel.blog_content))
    //        {
    //            item.blog_content = requestModel.blog_content;
    //        }

    //        _db.Entry(item).State = EntityState.Modified;
    //        var result = _db.SaveChanges();

    //        string message = result > 0 ? "Update Success." : "Update Fail!";
    //        model.IsSuccess = result > 0;
    //        model.Message = message;
    //    }
    //    else if (item is null)
    //    {
    //        model = CreateBlog(requestModel);
    //    }

    //    return model;
    //}
}
