using SnakeGame.ConsoleApp;
using SnakeGame.ConsoleApp.Model;

HttpClientService _httpService = new HttpClientService();
//var content = await _httpService.GetPlayers();
//Console.WriteLine(content.IsSuccess);
//Console.WriteLine(content.Message);
//foreach (var player in content.Data)
//{
//    Console.WriteLine(player.PlayerId);
//    Console.WriteLine(player.PlayerName);
//    Console.WriteLine(player.CurrentPosition);
//}
//Console.ReadLine();

//var player = new List<PlayerModel>
//{
//    new PlayerModel{PlayerName = "Myo Myo"},
//    new PlayerModel{PlayerName = "Mya Mya"},
//    new PlayerModel{PlayerName = "Aye Aye"}
//};
//var request = new GameRequestModel
//{
//    Players = player,
//};
//var content = await _httpService.CreateGame(request);
//Console.WriteLine(content.IsSuccess);
//Console.WriteLine(content.Message);
//Console.ReadLine();

//var content = await _httpService.PlayGame(new GameMovesRequestModel
//{
//    PlayerId = 8
//});
//Console.WriteLine(content.Message);
//Console.WriteLine($"Current Cell : {content.CurrentCell}");
//Console.WriteLine($"Dice Number : {content.DiceNumber}");
//Console.ReadLine();

//RestClientService _restService = new RestClientService();
//var content = await _restService.GetPlayer();
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine(content.Message);
//Console.WriteLine("\n{0,-5} {1,-10} {2,-20:C}", "Id", "Name", "Current Position");
//Console.WriteLine(new string('-', 35));
//foreach (var item in content.Data)
//{
//    Console.WriteLine("{0,-5} {1,-10} {2,-20}", item.PlayerId, item.PlayerName, item.CurrentPosition);
//}
//Console.ReadLine();

RefitService _refit =  new RefitService();
var content = await _refit.GetPlayer();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(content.Message);
Console.WriteLine("\n{0,-5} {1,-10} {2,-20:C}", "Id", "Name", "Current Position");
Console.WriteLine(new string('-', 35));
foreach (var item in content.Data)
{
    Console.WriteLine("{0,-5} {1,-10} {2,-20}", item.PlayerId, item.PlayerName, item.CurrentPosition);
}
Console.ReadLine();