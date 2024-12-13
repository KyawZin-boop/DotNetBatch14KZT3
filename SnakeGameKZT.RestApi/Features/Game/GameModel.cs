using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeGameKZT.RestApi.Features.Game;

[Table("tbl_games")]
public class GameModel
{
    [Key]
    public int? GameId { get; set; }
    public string? GameStatus { get; set; }
    public int? CurrentPlayerId { get; set; }
}

public class GameResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
