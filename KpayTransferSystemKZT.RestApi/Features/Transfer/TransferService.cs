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
        var item = _db.TransfersHistory!.AsNoTracking().FirstOrDefault(x => x.TransactionId == id);
        return item!;
    }

    public TransferResponseModel CreateTransfer(TransferRequestModel requestModel)
    {
        TransferResponseModel model = new TransferResponseModel();

        var sender = _db.Users!.FirstOrDefault(x => x.MobileNumber == requestModel.FromMobileNo);
        if (sender is null)
        {
            model.IsSuccess = false;
            model.Message = "Create account first with this mobile number!";
            return model;
        }

        if (sender.Password != requestModel.Password)
        {
            model.IsSuccess = false;
            model.Message = "Incorrect Password!";
            return model;
        }
        if (sender.Balance <= 10000 || (sender.Balance - 10000) <= requestModel.Amount)
        {
            model.IsSuccess = false;
            model.Message = "Not enough balance!";
            return model;
        }

        var receiver = _db.Users!.FirstOrDefault(x => x.MobileNumber == requestModel.ToMobileNo);
        if(receiver is null)
        {
            model.IsSuccess = false;
            model.Message = "There's no account with this mobile number";
            return model;
        }

        sender.Balance -= requestModel.Amount;
        receiver.Balance += requestModel.Amount;

        var history = new TransferModel
        {
            TransactionId = Guid.NewGuid().ToString(),
            FromMobileNo = requestModel.FromMobileNo,
            ToMobileNo = requestModel.ToMobileNo,
            Amount = requestModel.Amount,
            Date = DateTime.Now,
            Notes = requestModel.Notes,
        };

        _db.TransfersHistory!.Add(history);
        int result = _db.SaveChanges();

        string message = result > 0 ? "Successfully Transfer." : "Transfer Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
