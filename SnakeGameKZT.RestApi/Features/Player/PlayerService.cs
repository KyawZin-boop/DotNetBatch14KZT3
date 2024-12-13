using Microsoft.EntityFrameworkCore;

namespace SnakeGameKZT.RestApi.Features.Player;

public class PlayerService
{
    private readonly AppDbContext _db = new AppDbContext();

    public PlayerListResponseModel GetPlayers()
    {
        List<PlayerModel> lst = _db.Players.ToList();
        PlayerListResponseModel model = new PlayerListResponseModel();
        model.IsSuccess = true;
        model.Message = "Success.";
        model.Data = lst;

        return model;
    }

    public PlayerResponseModel GetPlayer(int id)
    {
        PlayerResponseModel model = new PlayerResponseModel();
        var player = _db.Players.AsNoTracking().FirstOrDefault(x => x.PlayerId == id);
        if (player is null)
        {
            model.Message = "Player not found!";
            return model;
        }

        model.IsSuccess = true;
        model.Message = "Success.";
        model.Data = player;

        return model;
    }

    public PlayerResponseModel CreatePlayer(PlayerModel requestModel)
    {
        PlayerResponseModel model = new PlayerResponseModel();
        var player = _db.Players.AsNoTracking().FirstOrDefault(x => x.PlayerName == requestModel.PlayerName);
        if (player is not null)
        {
            model.Message = "PlayerName already exist!";
            return model;
        }

        _db.Players.Add(requestModel);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Success." : "Create Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }
}
