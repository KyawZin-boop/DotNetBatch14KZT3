using RepoDB.Shared;

namespace RepoDB.MinimalApi.BlogEndpoint
{
    public static class BlogEndpoint
    {
        public static void MapBlogEndpoint(this IEndpointRouteBuilder app)
        {
            RepoDbService service = new RepoDbService();

            app.MapGet("/api/blogs", () =>
            {
                var model = service.GetBlogs();
                if (model is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(model);
            })
            .WithName("GetBlogs")
            .WithOpenApi();

            app.MapGet("/api/blogs/{id}", (string id) =>
            {
                var model = service.GetBlog(id);
                if (model is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(model);
            })
            .WithName("GetBlog")
            .WithOpenApi();

            app.MapPost("/api/blogs", (BlogModel model) =>
            {
                try
                {
                    service.CreateBlog(model);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
            .WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/api/blogs", (BlogModel model) =>
            {
                try
                {
                    service.UpdateBlog(model);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
            .WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/api/blogs/{id}", (string id) =>
            {
                try
                {
                    service.DeleteBlog(id);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
            .WithName("DeleteBlog")
            .WithOpenApi();
        }
    }
}
