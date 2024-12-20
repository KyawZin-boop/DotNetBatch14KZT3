using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SnakeGame.ConsoleApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeGame.ConsoleApp;

public class HttpClientService
{
    private readonly string endpoint = "https://localhost:7126/api";
    private readonly HttpClient _client;

    public HttpClientService()
    {
        _client = new HttpClient();
    }

    public async Task<PlayerListResponseModel> GetPlayers()
    {
        HttpResponseMessage response = await _client.GetAsync($"{endpoint}/Player");
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PlayerListResponseModel>(content)!;
    }

    public async Task<GameResponseModel> CreateGame(GameRequestModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        StringContent stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _client.PostAsync($"{endpoint}/Game", stringContent);
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<GameResponseModel>(content)!;
    }

    public async Task<GameMovesResponseModel> PlayGame(GameMovesRequestModel requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        StringContent stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _client.PostAsync($"{endpoint}/GameMoves", stringContent);
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<GameMovesResponseModel>(content)!;
    }
}
