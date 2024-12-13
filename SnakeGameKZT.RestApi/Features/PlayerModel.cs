using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeGameKZT.RestApi.Features;

[Table("tbl_player")]
public class PlayerModel
{
    [Key]
    public int? PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public int? CurrentPosition { get; set; }
}

public class PlayerResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public PlayerModel Data { get; set; }
}

public class PlayerListResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public List<PlayerModel> Data { get; set; }
}