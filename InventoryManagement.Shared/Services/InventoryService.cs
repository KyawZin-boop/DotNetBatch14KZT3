using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementDB.shared.AppSettings;
using InventoryManagementDB.shared.Model;

namespace InventoryManagement.Shared.Services;

public class InventoryService
{
    private readonly AppDbContext _db;
    public List<Inventory> inventory;

    public InventoryService()
    {
        _db = new AppDbContext();
        inventory = new List<Inventory>();
    }

    public ResponseModel AddToInventory(Product inputModel)
    {
        var item = inventory.FirstOrDefault(x => x.Item.ProductId == inputModel.ProductId);
        if(item is not null)
        {
            item.Item.Quantity += inputModel.Quantity;
            return new ResponseModel { Message = "Product added to inventory successfully.", IsSuccess = true };
        }

        var model = new Inventory
        {
            Item = inputModel
        };
        inventory.Add(model);
        return new ResponseModel { Message = "Product added to inventory successfully.", IsSuccess = true };
    }

    public ResponseModel RemoveFromInventory(Guid id)
    {
        var model = inventory.FirstOrDefault(x => x.Item.ProductId == id);
        if (model is null)
        {
            return new ResponseModel { Message = "Product not found in inventory." };
        }
        inventory.Remove(model);
        return new ResponseModel { Message = "Product removed from inventory successfully.", IsSuccess = true };
    }

    public ResponseModel UpdateInventoryItem(Guid id, ProductDTO inputModel)
    {
        var item = inventory.FirstOrDefault(x => x.Item.ProductId == id);
        if (item is null)
        {
            return new ResponseModel { Message = "Product not found in inventory." };
        }

        item.Item.ProductName = inputModel.ProductName;
        item.Item.Quantity = inputModel.Quantity;
        return new ResponseModel { Message = "Product updated successfully.", IsSuccess = true };
    }

    public ResponseModel GetInventory()
    {
        var model = inventory.ToList();
        if (model is null)
        {
            return new ResponseModel { Message = "Inventory not found." };
        }

        return new ResponseModel { Message = "Success.", IsSuccess = true, Data = model };
    }
}
