using Microsoft.AspNetCore.Mvc;

namespace SnakeGameKZT.RestApi.Features.GameBoard;

public class GameBoardService
{
    private readonly AppDbContext _db = new AppDbContext();

    public GameBoardResponseModel CreateBoard()
    {
        return new GameBoardResponseModel
        {
            IsSuccess = true,
            Message = "Success."
        };
        Random random = new Random();
        string[] type = { "Normal", "SnakeHead", "Normal", "SnakeTail", "Normal", "LadderBottom", "Normal", "LadderTop", "Normal" };
        for(int i = 1; i <= 100; i++)
        {
            var model = new GameBoardModel
            {
                CellNumber = i,
                CellType = type[random.Next(0, type.Length)],
            };
            _db.Add(model);
        }

        var result = _db.SaveChanges();
        string message = result > 0 ? "Create Success." : "Create Fail!";
        return new GameBoardResponseModel
        {
            IsSuccess = result > 0,
            Message = message
        };
    }
}
