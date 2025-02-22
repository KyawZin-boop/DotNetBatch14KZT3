﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT3.ConsoleApp5;

[Table("tbl_blog")]
public class BlogModel
{
    [Key]
    public string? blog_id { get; set; }
    public string? blog_title { get; set; }
    public string? blog_author { get; set; }
    public string? blog_content { get; set; }
}

public class BlogResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public BlogModel? Data { get; set; }
}

public class BlogListResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public List<BlogModel>? Data { get; set; }
}
