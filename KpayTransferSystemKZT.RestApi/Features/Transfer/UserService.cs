using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer;

public class UserService
{
    private readonly AppDbContext _db = new AppDbContext();

    public List<UserModel> GetUsers()
    {
        List<UserModel> lst = _db.Users!.ToList();
        return lst;
    }

    public UserModel GetUser(string id)
    {
        var item = _db.Users!.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        return item!;
    }

    public UserResponseModel CreateUser(UserModel requestUser)
    {
        UserResponseModel model = new UserResponseModel();
        var name = _db.Users!.AsNoTracking().FirstOrDefault(x => x.UserName == requestUser.UserName);
        if(name is not null)
        {
            model.IsSuccess = false;
            model.Message = "UserName already exist!";
            return model;
        }

        var phone = _db.Users!.AsNoTracking().FirstOrDefault(x => x.MobileNumber ==  requestUser.MobileNumber);
        if(phone is not null)
        {
            model.IsSuccess = false;
            model.Message = "Phone number already exist!";
            return model;
        }

        _db.Users!.Add(requestUser);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public UserResponseModel UpdateUser(UserModel requestUser)
    {
        var user = _db.Users!.AsNoTracking().FirstOrDefault(x => x.UserId == requestUser.UserId);
        if(user is null)
        {
            return new UserResponseModel()
            {
                IsSuccess = false,
                Message = "No user found!"
            };
        }

        if (!string.IsNullOrEmpty(requestUser.UserName))
        {
            user.UserName = requestUser.UserName;
        }
        if (!string.IsNullOrEmpty(requestUser.MobileNumber))
        {
            user.MobileNumber = requestUser.MobileNumber;
        }
        if (!string.IsNullOrEmpty(requestUser.Password))
        {
            user.Password = requestUser.Password;
        }

        _db.Entry(user).State = EntityState.Modified;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Update Success." : "Update Fail!";
        UserResponseModel model = new UserResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public UserResponseModel UpsertUser(UserModel requestUser)
    {
        UserResponseModel model = new UserResponseModel();

        var user = _db.Users!.AsNoTracking().FirstOrDefault(x => x.UserId == requestUser.UserId);
        if(user is not null)
        {
            if (!string.IsNullOrEmpty(requestUser.UserName))
            {
                user.UserName = requestUser.UserName;
            }
            if (!string.IsNullOrEmpty(requestUser.MobileNumber))
            {
                user.MobileNumber = requestUser.MobileNumber;
            }
            if (!string.IsNullOrEmpty(requestUser.Password))
            {
                user.Password = requestUser.Password;
            }

            _db.Entry(user).State = EntityState.Modified;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Update Success." : "Update Fail!";
            model.IsSuccess = result > 0;
            model.Message = message;
        }
        else if(user is null)
        {
            model = CreateUser(requestUser);
        }

        return model;
    }

    public UserResponseModel DeleteUser(string id)
    {
        UserResponseModel model = new UserResponseModel();

        var user = _db.Users!.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        if(user is null)
        {
            model.IsSuccess = false;
            model.Message = "No user found!";
        }

        _db.Entry(user).State = EntityState.Deleted;
        var result = _db.SaveChanges();

        string message = result > 0 ? "Delete Success." : "Delete Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
