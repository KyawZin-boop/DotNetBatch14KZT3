namespace MiniPosSystemKZT.RestApi.Features.POS;

public class TransactionService
{
    private readonly AppDbContext _db = new AppDbContext();

    public List<TransactionModel> GetHistories()
    {
        List<TransactionModel> lst = _db.Transaction!.ToList();
        return lst;
    }

    public TransactionModel GetHistory(string id)
    {
        var item = _db.Transaction!.FirstOrDefault(x => x.Id == id);
        return item!;
    }

    public TransactionRequestModel CreateHistory(TransactionModel requestModel)
    {
        _db.Add(requestModel);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        TransactionRequestModel model = new TransactionRequestModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
