using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.ConsoleApp.Model;

public class GameBoardModel
{
    public int BoardId { get; set; }
    public int CellNumber { get; set; }
    public string CellType { get; set; }
    public int MoveToCell { get; set; }
}

public class GameBoardResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
