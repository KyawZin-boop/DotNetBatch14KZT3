using InventoryDB.Shared.Model;
using InventoryManagement.Shared.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InventoryManagement.MinimalApi.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        ProductService productService = new ProductService();

        app.MapGet("/api/Product", () =>
        {
            var products = productService.GetProducts();
            if (products is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(products);
        })
        .WithName("GetProducts")
        .WithOpenApi();

        app.MapGet("/api/Product/{id}", (Guid id) =>
        {
            var product = productService.GetProduct(id);
            if (product is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        })
        .WithName("GetProduct")
        .WithOpenApi();

        app.MapPost("/api/Product/AddProduct", (ProductDTO inputModel) =>
        {
            try
            {
                var result = productService.AddProduct(inputModel);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .WithName("AddProduct")
        .WithOpenApi();

        app.MapPost("/api/Product/UpdateProduct", (Guid id, ProductDTO inputModel) =>
        {
            try
            {
                var model = productService.UpdateProduct(id, inputModel);
                return Results.Ok(model);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
            .WithName("UpdateProduct")
            .WithOpenApi();

        app.MapDelete("/api/Product/DeleteProduct", (Guid id) =>
        {
            try
            {
                var model = productService.DeleteProduct(id);
                return Results.Ok(model);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
            .WithName("DeleteProduct")
            .WithOpenApi();
    }
}
