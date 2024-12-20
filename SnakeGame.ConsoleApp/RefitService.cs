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

    public async Task<PlayerListResponseModel> GetPlayer()
    {
        var model = await _api.GetPlayer();
        return model;
    }
}

public interface ISnakeGameApi
{
    [Get("/api/Player")]
    Task<PlayerListResponseModel> GetPlayer();
}
