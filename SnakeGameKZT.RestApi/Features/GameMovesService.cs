using Microsoft.EntityFrameworkCore;

namespace SnakeGameKZT.RestApi.Features;

public class GameMovesService
{
    private readonly AppDbContext _db = new AppDbContext();

    public GameMovesResponseModel CreateMove(GameMovesRequestModel requestModel)
    {
        var player = _db.Players.AsNoTracking().FirstOrDefault(x => x.PlayerId == requestModel.PlayerId);
        if(player is null)
        {
            return new GameMovesResponseModel
            {
                Message = "Please enter a valid Id!",
            };
        }

        var game = _db.Games.AsNoTracking().FirstOrDefault(x => x.CurrentPlayerId == requestModel.PlayerId);

        if(game.GameStatus == "Finish")
        {
            return new GameMovesResponseModel
            {
                Message = "The game was finished!",
            };
        }

        Random random = new Random();
        int diceRoll = random.Next(1, 7);

        var move = new GameMovesModel
        {
            GameId = game!.GameId,
            PlayerId = player!.PlayerId,
            FromCell = player.CurrentPosition,
            ToCell = (player.CurrentPosition + diceRoll),
        };

        player.CurrentPosition += diceRoll;
        if(player.CurrentPosition >= 100)
        {
            game.GameStatus = "Finish";
            return new GameMovesResponseModel
            {
                IsSuccess = true,
                Message = "Congratulation! You Won the game!",
            };
        }

        _db.Entry(player).State = EntityState.Modified;
        _db.Entry(game).State = EntityState.Modified;
        _db.GameMoves.Add(move);

        var result = _db.SaveChanges();
        string message = result > 0 ? "Move Success." : "Move Fail!";
        GameMovesResponseModel model = new GameMovesResponseModel()
        {
            IsSuccess = result > 0,
            Message = message,
            CurrentCell = player.CurrentPosition,
        };

        return model;
    }
}
