using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InventoryDB.Shared.AppSettings;
using InventoryDB.Shared.Model;
using Newtonsoft.Json;

namespace InventoryManagement.Shared.Services;

public class OrderService
{
    private readonly AppDbContext _db;

    public OrderService()
    {
        _db = new AppDbContext();
    }

    public ResponseModel CreateOrder(List<Product> inputModel)
    {
        decimal totalPrice = 0;
        foreach (var item in inputModel)
        {
            totalPrice += (item.Price * item.Quantity);
        }
        var order = new Order
        {
            Items = JsonConvert.SerializeObject(inputModel),
            TotalPrice = totalPrice
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
        var obj = JsonConvert.DeserializeObject<List<Product>>(order.Items);
        foreach (var item in obj)
        {
            if (item.ProductID == product.ProductID)
            {
                return new ResponseModel { Message = "Item already exists in order." };
            }
        }

        obj.Add(product);
        order.Items = JsonConvert.SerializeObject(obj);
        order.TotalPrice += product.Price * product.Quantity;
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

        var obj = JsonConvert.DeserializeObject<List<Product>>(order.Items);
        var product = obj.FirstOrDefault(obj => obj.ProductID == ItemId);

        if (product is null)
        {
            return new ResponseModel { Message = "Product not found" };
        }

        obj.Remove(product);
        order.TotalPrice -= product.Quantity * product.Price;
        order.Items = JsonConvert.SerializeObject(obj);
        _db.Order.Update(order);

        var result = _db.SaveChanges();
        if (result > 0)
        {
            return new ResponseModel { Message = "Item removed from order successfully.", IsSuccess = true };
        }

        return new ResponseModel { Message = "Failed to remove item from order." };
    }

    public Order GetOrderDetails(Guid OrderId)
    {
        var order = _db.Order.FirstOrDefault(x => x.OrderID == OrderId);
        if (order is null)
        {
            throw new Exception("Order not found.");
        }

        return order;
    }
}
