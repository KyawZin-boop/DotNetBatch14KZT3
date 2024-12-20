// See https://aka.ms/new-console-template for more information
using DotNetBatch14KZT3.ConsoleApp4;

//BlogHttpClientService httpClient = new BlogHttpClientService();
//await httpClient.GetBlogs();
//await httpClient.GetBlog("d9882465-eb8a-4afa-9999-56aa7ff7d476");
//Console.ReadLine();

BlogRefitService refitBlog = new BlogRefitService();
var model = await refitBlog.GetBlogs();
Console.ReadLine();
