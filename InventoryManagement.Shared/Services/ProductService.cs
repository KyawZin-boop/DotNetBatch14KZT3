using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Shared.AppSettings;
using InventoryManagement.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Shared.Services;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService()
    {
        _db = new AppDbContext();
    }

    public ProductResponseModel GetProducts()
    {
        var model = _db.Product.ToList();
        if(model is null)
        {
            return new ProductResponseModel { Message = "Product not found."};
        }

        return new ProductResponseModel { Message = "Success.", IsSuccess = true, Data = model };
    }

    public ProductResponseModel GetProduct(Guid id)
    {
        var model = _db.Product.Find(id);
        if (model is null)
        {
            return new ProductResponseModel { Message = "Product not found."};
        }

        return new ProductResponseModel { Message = "Success.", IsSuccess = true, Data = model };
    }

    public ProductResponseModel AddProduct(ProdcutDTO requestModel)
    {
        var model = new Product
        {
            ProductName = requestModel.ProductName,
            Quantity = requestModel.Quantity,
            Price = requestModel.Price
        };
        _db.Product.Add(model);
        _db.SaveChanges();
        return new ProductResponseModel { Message = "Product added successfully.", IsSuccess = true};
    }

    public ProductResponseModel UpdateProduct(Guid id, ProdcutDTO requestModel)
    {
        var model = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == id);
        if (model is null)
        {
            return new ProductResponseModel { Message = "Product not found." };
        }
        model.ProductName = requestModel.ProductName;
        model.Quantity = requestModel.Quantity;
        model.Price = requestModel.Price;

        _db.Entry(model).State = EntityState.Modified;
        var result = _db.SaveChanges();

        if (result == 0)
        {
            return new ProductResponseModel { Message = "Product update failed." };
        }
        return new ProductResponseModel { Message = "Product updated successfully.", IsSuccess = true };
    }

    public ProductResponseModel DeleteProduct(Guid id)
    {
        var model = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == id);
        if (model is null)
        {
            return new ProductResponseModel { Message = "Product not found." };
        }
        _db.Entry(model).State = EntityState.Deleted;
        var result = _db.SaveChanges();

        if (result == 0)
        {
            return new ProductResponseModel { Message = "Product delete failed." };
        }
        return new ProductResponseModel { Message = "Product deleted successfully.", IsSuccess = true };
    }
}
