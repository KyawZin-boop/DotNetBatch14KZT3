using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.AppSettings;
using InventoryDB.Shared.Model;

namespace InventoryManagement.Shared.Services;

public class InventoryService
{
    private readonly AppDbContext _db;
    public static List<Inventory> InventoryList = new List<Inventory>();

    public InventoryService()
    {
        _db = new AppDbContext();
    }

    public ResponseModel AddToInventory(Product inputModel)
    {
        var item = InventoryList.FirstOrDefault(x => x.Item.ProductID == inputModel.ProductID);
        if(item is not null)
        {
            item.Item.Quantity += inputModel.Quantity;
            return new ResponseModel { Message = "Product added to inventory successfully.", IsSuccess = true };
        }
        
        var model = new Inventory
        {
            Item = inputModel
        };
        InventoryList.Add(model);
        return new ResponseModel { Message = "Product added to inventory successfully.", IsSuccess = true,Data = InventoryList };
    }

    public ResponseModel RemoveFromInventory(Guid id)
    {
        var model = InventoryList.FirstOrDefault(x => x.Item.ProductID == id);
        if (model is null)
        {
            return new ResponseModel { Message = "Product not found in inventory." };
        }
        InventoryList.Remove(model);
        return new ResponseModel { Message = "Product removed from inventory successfully.", IsSuccess = true };
    }

    public ResponseModel UpdateInventoryItem(Guid id, ProductDTO inputModel)
    {
        var item = InventoryList.FirstOrDefault(x => x.Item.ProductID == id);
        if (item is null)
        {
            return new ResponseModel { Message = "Product not found in inventory." };
        }

        item.Item.ProductName = inputModel.ProductName;
        item.Item.Quantity = inputModel.Quantity;
        return new ResponseModel { Message = "Product updated successfully.", IsSuccess = true };
    }

    public List<Inventory> GetInventory()
    {
        var model = InventoryList.ToList();
        if (model is null)
        {
           throw new Exception("Inventory not found.");
        }

        return model;
    }
}
