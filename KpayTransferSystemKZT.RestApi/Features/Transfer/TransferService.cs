using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer;

public class TransferService
{
    private readonly AppDbContext _db = new AppDbContext();

    public List<TransferModel> GetRecords()
    {
        List<TransferModel> lst = _db.TransfersHistory!.ToList();
        return lst;
    }

    public TransferModel GetRecord(string id)
    {
        var item = _db.TransfersHistory!.AsNoTracking().FirstOrDefault(x => x.Id == id);
        return item!;
    }

    public TransferResponseModel CreateTransfer(UserModel user, string fromMobile, string toMobile, string password, decimal amount, string notes)
    {
        TransferResponseModel model = new TransferResponseModel();

        var sender = _db.Users!.FirstOrDefault(x => x.MobileNumber == fromMobile);
        if (sender is null)
        {
            model.IsSuccess = false;
            model.Message = "Create account first with this mobile number!";
            return model;
        }

        if (sender.Password != password)
        {
            model.IsSuccess = false;
            model.Message = "Incorrect Password!";
            return model;
        }
        if (sender.Balance <= 10000 || (sender.Balance - 10000) <= amount)
        {
            model.IsSuccess = false;
            model.Message = "Not enough balance!";
            return model;
        }

        var receiver = _db.Users!.FirstOrDefault(x => x.MobileNumber == toMobile);
        if(receiver is null)
        {
            model.IsSuccess = false;
            model.Message = "There's no account with this mobile number";
            return model;
        }

        sender.Balance -= amount;
        receiver.Balance += amount;

        var history = new TransferModel
        {
            Id = Guid.NewGuid().ToString(),
            FromMobile = fromMobile,
            ToMobile = toMobile,
            Amount = amount,
            Date = DateTime.UtcNow,
            Notes = notes,
        };

        _db.TransfersHistory!.Add(history);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Successfully Transfer." : "Transfer Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
