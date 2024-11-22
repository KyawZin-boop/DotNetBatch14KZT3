using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KZT3.ConsoleApp2.EFCoreExamples;

public class EFCoreExample
{
    private readonly AppDbContext _db = new AppDbContext();

    public void Read()
    {
        var list = _db.Blogs.ToList();
        foreach (var item in list)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Title);
            Console.WriteLine(item.Author);
            Console.WriteLine(item.Content);
            Console.WriteLine("");
        }
    }

    public void Edit(string id)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        Console.WriteLine(item.Id);
        Console.WriteLine(item.Title);
        Console.WriteLine(item.Author);
        Console.WriteLine(item.Content);
    }

    public void Create(string title, string author, string content)
    {
        var blog = new TblBlog
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Author = author,
            Content = content
        };

        _db.Blogs.Add(blog);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string  author, string content)
    {
        var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        item.Title = title;
        item.Author = author;
        item.Content = content;

        _db.Entry(item).State = EntityState.Modified;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Update Success." : "Update Fail!";
        Console.WriteLine(message);
    }

    public void Delete(string id)
    {
        var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        _db.Entry(item).State = EntityState.Deleted;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        Console.WriteLine(message);
    }
}
