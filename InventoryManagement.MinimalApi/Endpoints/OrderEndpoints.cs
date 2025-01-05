using InventoryDB.Shared.Model;
using InventoryManagement.Shared.Services;

namespace InventoryManagement.MinimalApi.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
        {
            OrderService service = new OrderService();

            app.MapGet("/api/Order", (Guid id) =>
            {
                var order = service.GetOrderDetails(id);
                if (order is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(order);
            })
                .WithName("GetOrderDetails")
                .WithOpenApi();

            app.MapPost("/api/Order/CreateOrder", (List<Product> product) =>
            {
                var order = service.CreateOrder(product);
                return Results.Ok(order);
            })
                .WithName("GetOrderDetails")
                .WithOpenApi();

            app.MapPost("/api/Order/AddItemToOrder", (Guid orderId, Product product) =>
            {
                var model = service.AddItemToOrder(orderId, product);
                return Results.Ok(model);
            })
                .WithName("AddItemToOrder")
                .WithOpenApi();

            app.MapDelete("/api/Order/RemoveItemFromOrder", (Guid orderId, Guid productId) =>
            {
                var model = service.RemoveItemFromOrder(orderId, productId);
                return Results.Ok(model);
            })
                .WithName("RemoveItemFromOrder")
                .WithOpenApi();
        }
    }
}
