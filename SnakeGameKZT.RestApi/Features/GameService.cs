using Microsoft.EntityFrameworkCore;

namespace SnakeGameKZT.RestApi.Features;

public class GameService
{
    private readonly AppDbContext _db = new AppDbContext();

    public GameResponseModel CreateGame(PlayerModel requestModel)
    {
        GameResponseModel model = new GameResponseModel();
        var player = _db.Players.AsNoTracking().FirstOrDefault(x => x.PlayerName == requestModel.PlayerName);
        if(player is null)
        {
            model.Message = "There's no player with this name!";
            return model;
        }

        var game = new GameModel
        {
            GameStatus = "InProgress",
            CurrentPlayerId = player.PlayerId,
        };

        _db.Games.Add(game);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Game Success." : "Create Game Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }


}
