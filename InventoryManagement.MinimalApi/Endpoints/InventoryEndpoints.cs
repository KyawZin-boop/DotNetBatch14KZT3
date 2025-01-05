using InventoryDB.Shared.Model;
using InventoryManagement.Shared.Services;

namespace InventoryManagement.MinimalApi.Endpoints
{
    public static class InventoryEndpoints
    {
        public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
        {
            InventoryService service = new InventoryService();

            app.MapGet("/api/Inventory", () =>
            {
                var inventory = service.GetInventory();
                if (inventory is null)
                {
                    return Results.NotFound("Inventory not found!");
                }

                return Results.Ok(inventory);
            })
                .WithName("GetInventory")
                .WithOpenApi();

            app.MapPost("/api/Inventory/AddToInventory", (Product product) =>
            {
                var model = service.AddToInventory(product);
                return Results.Ok(model);
            })
                .WithName("AddToInventory")
                .WithOpenApi();

            app.MapDelete("/api/Inventory/RemoveFromInventory", (Guid id) =>
            {
                var model = service.RemoveFromInventory(id);
                return Results.Ok(model);
            })
                .WithName("RemoveFromInventory")
                .WithOpenApi();

            app.MapPost("/api/Inventory/UpdateInventoryItem/{id}", (Guid id, ProductDTO product) =>
            {
                var model = service.UpdateInventoryItem(id, product);
                return Results.Ok(model);
            })
                .WithName("UpdateInventoryItem")
                .WithOpenApi();
        }
    }
}
