using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp.Model;

public class PlayerModel
{
    public int? PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public int? CurrentPosition { get; set; } = 0;
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

public class PlayerRequestModel
{
    public string? PlayerName { get; set; }
}

