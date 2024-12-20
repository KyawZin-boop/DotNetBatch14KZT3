using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using SnakeGame.ConsoleApp.Model;

namespace SnakeGame.ConsoleApp;

public class RefitService
{
    private readonly string domain = "https://localhost:7126";
    private readonly ISnakeGameApi _api;

    public RefitService()
    {
        _api = RestService.For<ISnakeGameApi>(domain);
    }

    public async Task<PlayerListResponseModel> GetPlayers()
    {
        var model = await _api.GetPlayers();
        return model;
    }

    public async Task<GameResponseModel> CreateGame(GameRequestModel requestModel)
    {
        var model = await _api.CreateGame(requestModel);
        return model;
    }

    public async Task<GameMovesResponseModel> PlayGame(GameMovesRequestModel requestModel)
    {
        var model = await _api.PlayGame(requestModel);
        return model;
    }
}

public interface ISnakeGameApi
{
    [Get("/api/Player")]
    Task<PlayerListResponseModel> GetPlayers();

    [Post("/api/Game")]
    Task<GameResponseModel> CreateGame(GameRequestModel requestModel);

    [Post("/api/GameMoves")]
    Task<GameMovesResponseModel> PlayGame(GameMovesRequestModel requestModel);
}
