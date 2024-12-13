using Microsoft.EntityFrameworkCore;

namespace SnakeGameKZT.RestApi.Features.GameMoves;

public class GameMovesService
{
    private readonly AppDbContext _db = new AppDbContext();

    public GameMovesResponseModel CreateMove(GameMovesRequestModel requestModel)
    {
        GameMovesResponseModel model = new GameMovesResponseModel();
        var player = _db.Players.AsNoTracking().FirstOrDefault(x => x.PlayerId == requestModel.PlayerId);
        if (player is null)
        {
            model.Message = "Please enter a valid Id!";
            return model;
        }

        #region Validate Game
        var game = _db.Games.AsNoTracking().FirstOrDefault(x => x.CurrentPlayerId == requestModel.PlayerId);
        if(game is null)
        {
            model.Message = "The game is not exist! Please create one.";
            return model;
        }
        if (game.GameStatus == "Finish")
        {
            model.Message = "The game was finished!";
            return model;
        }
        #endregion

        Random random = new Random();
        int diceRoll = random.Next(1, 7);

        int? FromCell = player.CurrentPosition;
        int? ToCell = player.CurrentPosition + diceRoll;

        var board = _db.GameBoard.AsNoTracking().FirstOrDefault(x => x.CellNumber == ToCell);
        if(board!.CellType == "LadderBottom" || board.CellType == "SnakeHead")
        {
            ToCell = board.MoveToCell;
            model.Message = board.CellType == "LadderBottom" ? "U got Ladder and Move Up!" : "U have eaten by a snake!";
        }

        var move = new GameMovesModel
        {
            GameId = game!.GameId,
            PlayerId = player!.PlayerId,
            FromCell = FromCell,
            ToCell = ToCell,
        };

        player.CurrentPosition = ToCell;
        if (player.CurrentPosition >= 100)
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
        model.IsSuccess = result > 0;
        if(model.Message is null)
        {
            model.Message = message;
        }
        model.CurrentCell = player.CurrentPosition;

        return model;
    }
}
