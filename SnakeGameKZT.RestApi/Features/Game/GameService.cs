using Microsoft.EntityFrameworkCore;
using SnakeGameKZT.RestApi.Features.Player;

namespace SnakeGameKZT.RestApi.Features.Game;

public class GameService
{
    private readonly AppDbContext _db = new AppDbContext();

    public GameResponseModel CreateGame(GameRequestModel requestModel)
    {
        GameResponseModel model = new GameResponseModel();
        int? firstPlayer = null;

        for(int i = 0; i < requestModel.Players.Count; i++) {
            _db.Players.Add(requestModel.Players[i]);
            _db.SaveChanges();

            if (i == 0)
            {
                firstPlayer = requestModel.Players[i].PlayerId;
            }
        }
        var game = new GameModel
        {
            GameStatus = "InProgress",
            CurrentPlayerId = firstPlayer,
            PlayerCount = requestModel.Players.Count,
        };

        _db.Games.Add(game);
        var result = _db.SaveChanges();

        string message = result > 0 ? "Create Game Success." : "Create Game Fail!";
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }


}
