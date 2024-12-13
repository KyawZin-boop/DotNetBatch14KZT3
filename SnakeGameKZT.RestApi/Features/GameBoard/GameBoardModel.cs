using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeGameKZT.RestApi.Features.GameBoard;

[Table("tbl_gameboard")]
public class GameBoardModel
{
    [Key]
    public int? BoardId { get; set; }
    public int? CellNumber { get; set; }
    public string? CellType { get; set; }
    public int? MoveToCell { get; set; }
}

public class GameBoardResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
