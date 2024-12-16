using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SnakeGameKZT.RestApi.Features.Player;

namespace SnakeGameKZT.RestApi.Features.Game;

[Table("Tbl_Game")]
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
