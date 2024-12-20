using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp.Model;


public class GameModel
{
    [Key]
    public int? GameId { get; set; }
    public string? GameStatus { get; set; }
    public int? CurrentPlayerId { get; set; }
    public int? PlayerCount { get; set; }
}

public class GameResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}

public class GameRequestModel
{
    public List<PlayerModel> Players { get; set; }
}

