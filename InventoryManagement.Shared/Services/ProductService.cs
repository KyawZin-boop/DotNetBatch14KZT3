using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.AppSettings;
using InventoryDB.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Shared.Services;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService()
    {
        _db = new AppDbContext();
    }

    public List<Product> GetProducts()
    {
        var model = _db.Product.AsNoTracking().ToList();
        if(model is null)
        {
            throw new Exception("Product not found");
        }

        return model;
    }

    public Product GetProduct(Guid id)
    {
        var product = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductID == id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public ResponseModel AddProduct(ProductDTO requestModel)
    {
        var model = new Product
        {
            ProductName = requestModel.ProductName,
            Quantity = requestModel.Quantity,
            Price = requestModel.Price
        };
        _db.Product.Add(model);
        _db.SaveChanges();
        return new ResponseModel { Message = "Product added successfully.", IsSuccess = true};
    }

    public ResponseModel UpdateProduct(Guid id, ProductDTO requestModel)
    {
        var model = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductID == id);
        if (model is null)
        {
            return new ResponseModel { Message = "Product not found." };
        }
        model.ProductName = requestModel.ProductName;
        model.Quantity = requestModel.Quantity;
        model.Price = requestModel.Price;

        _db.Entry(model).State = EntityState.Modified;
        var result = _db.SaveChanges();

        if (result == 0)
        {
            return new ResponseModel { Message = "Product update failed." };
        }
        return new ResponseModel { Message = "Product updated successfully.", IsSuccess = true };
    }

    public ResponseModel DeleteProduct(Guid id)
    {
        var model = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductID == id);
        if (model is null)
        {
            return new ResponseModel { Message = "Product not found." };
        }
        _db.Entry(model).State = EntityState.Deleted;
        var result = _db.SaveChanges();

        if (result == 0)
        {
            return new ResponseModel { Message = "Product delete failed." };
        }
        return new ResponseModel { Message = "Product deleted successfully.", IsSuccess = true };
    }
}
