using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementDB.Shared.AppSettings;
using InventoryManagementDB.Shared.Model;

namespace InventoryManagement.Shared.Services;

public class OrderService
{
    private readonly AppDbContext _db;

    public OrderService()
    {
        _db = new AppDbContext();
    }

    public ResponseModel CreateOrder(List<Product> products)
    {
        var order = new Order
        {
            Items = products,
            TotalPrice = products.Sum(x => x.Price)
        };

        _db.Order.Add(order);
        var result = _db.SaveChanges();
        if (result > 0)
        {
            return new ResponseModel { Message = "Order created successfully.", IsSuccess = true };
        }

        return new ResponseModel { Message = "Failed to create order." };
    }

    public ResponseModel AddItemToOrder(Guid OrderId, Product product)
    {
        var order = _db.Order.FirstOrDefault(x => x.OrderID == OrderId);
        if (order is null)
        {
            return new ResponseModel { Message = "Order not found." };
        }

        order.Items.Add(product);
        order.TotalPrice += product.Price;
        _db.Order.Update(order);

        var result = _db.SaveChanges();
        if (result > 0)
        {
            return new ResponseModel { Message = "Item added to order successfully.", IsSuccess = true };
        }

        return new ResponseModel { Message = "Failed to add item to order." };
    }

    public ResponseModel RemoveItemFromOrder(Guid OrderId, Guid ItemId)
    {
        var order = _db.Order.FirstOrDefault(x => x.OrderID == OrderId);
        if (order is null)
        {
            return new ResponseModel { Message = "Order not found." };
        }

        var item = order.Items.FirstOrDefault(x => x.ProductID == ItemId);
        if (item is null)
        {
            return new ResponseModel { Message = "Item not found in order." };
        }

        order.Items.Remove(item);
        order.TotalPrice -= item.Price;
        _db.Order.Update(order);

        var result = _db.SaveChanges();
        if (result > 0)
        {
            return new ResponseModel { Message = "Item removed from order successfully.", IsSuccess = true };
        }

        return new ResponseModel { Message = "Failed to remove item from order." };
    }

    public ResponseModel GetOrderDetails(Guid OrderId)
    {
        var order = _db.Order.FirstOrDefault(x => x.OrderID == OrderId);
        if (order is null)
        {
            return new ResponseModel { Message = "Order not found." };
        }

        return new ResponseModel { Message = "Success.", IsSuccess = true, Data = order };
    }
}
