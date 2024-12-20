using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp.Model;

public class GameMovesModel
{
    public int MoveId { get; set; }
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int DiceNumber { get; set; }
    public int FromCell { get; set; }
    public int ToCell { get; set; }
    public DateTime MoveDate { get; set; }
}

public class GameMovesResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public int? DiceNumber { get; set; }
    public int? CurrentCell { get; set; }
}

public class GameMovesRequestModel
{
    public int? PlayerId { get; set; }
}

