using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeGameKZT.RestApi.Features;

[Table("tbl_game_moves")]
public class GameMovesModel
{
    [Key]
    public int? MoveId { get; set; }
    public int? GameId { get; set; }
    public int? PlayerId { get; set; }
    public int? FromCell {  get; set; }
    public int? ToCell { get; set; }
    public DateTime MoveDate { get; set; } = DateTime.UtcNow;
}

public class GameMovesResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public int? CurrentCell { get; set; }
}

public class GameMovesRequestModel
{
    public int? PlayerId { get; set; }
}
