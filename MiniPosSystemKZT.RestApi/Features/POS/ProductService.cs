using Microsoft.EntityFrameworkCore;

namespace MiniPosSystemKZT.RestApi.Features.POS
{
    public class ProductService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> lst = _db.Product.AsNoTracking().ToList();
            return lst;
        }

        public ProductModel GetProduct(string id)
        {
            var item = _db.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == id);
            return item!;
        }

        public ProductResponseModel CreateProduct(ProductModel requestModel)
        {
            var item = _db.Product.AsNoTracking().FirstOrDefault(x => x.Name == requestModel.Name);
            if(item is not null)
            {
                return new ProductResponseModel
                {
                    IsSuccess = false,
                    Message = "Product already exist!"
                };
            }

            _db.Add(requestModel);
            var result = _db.SaveChanges();

            string message = result > 0 ? "Create Success." : "Create Fail!";
            ProductResponseModel model = new ProductResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ProductResponseModel UpdateProduct(ProductModel requestModel)
        {
            var item = _db.Product!.AsNoTracking().FirstOrDefault(x => x.ProductId ==  requestModel.ProductId);
            if (item is null)
            {
                return new ProductResponseModel()
                {
                    IsSuccess = false,
                    Message = "No item found!"
                };
            }

            if (!string.IsNullOrEmpty(requestModel.Name))
            {
                item.Name = requestModel.Name;
            }
            if (!string.IsNullOrEmpty(requestModel.Price.ToString()))
            {
                item.Price = requestModel.Price;
            }
            if (!string.IsNullOrEmpty(requestModel.Quantity.ToString()))
            {
                item.Quantity = requestModel.Quantity;
            }

            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Update Success." : "Update Fail!";
            ProductResponseModel model = new ProductResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ProductResponseModel UpsertProduct(ProductModel requestModel)
        {
            ProductResponseModel model = new ProductResponseModel();

            var item= _db.Product!.AsNoTracking().FirstOrDefault(x => x.ProductId == requestModel.ProductId);
            if (item is not null)
            {
                if (!string.IsNullOrEmpty(requestModel.Name))
                {
                    item.Name = requestModel.Name;
                }
                if (!string.IsNullOrEmpty(requestModel.Price.ToString()))
                {
                    item.Price = requestModel.Price;
                }
                if (!string.IsNullOrEmpty(requestModel.Quantity.ToString()))
                {
                    item.Quantity = requestModel.Quantity;
                }

                _db.Entry(item).State = EntityState.Modified;
                var result = _db.SaveChanges();

                string message = result > 0 ? "Update Success." : "Update Fail!";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateProduct(requestModel);
            }

            return model;
        }

        public ProductResponseModel DeleteProduct(string id)
        {
            ProductResponseModel model = new ProductResponseModel();

            var item = _db.Product!.AsNoTracking().FirstOrDefault(x => x.ProductId == id);
            if(item is null)
            {
                model.IsSuccess = false;
                model.Message = "No item found!";
                return model;
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
