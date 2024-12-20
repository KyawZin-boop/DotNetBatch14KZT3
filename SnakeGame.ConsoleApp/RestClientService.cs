﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SnakeGame.ConsoleApp.Model;

namespace SnakeGame.ConsoleApp;

public class RestClientService
{
    private readonly string endpoint = "https://localhost:7126/api";
    private readonly RestClient _restClient;

    public RestClientService()
    {
        _restClient = new RestClient();
    }

    public async Task<PlayerListResponseModel> GetPlayer()
    {
        RestRequest request = new RestRequest($"{endpoint}/Player", Method.Get);
        RestResponse response = await _restClient.ExecuteAsync(request);
        var content = response.Content!;
        return JsonConvert.DeserializeObject<PlayerListResponseModel>(content)!;
    }

    public async Task<GameResponseModel> CreateGame(GameRequestModel requestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/Game", Method.Post);
        request.AddJsonBody(requestModel);
        RestResponse response = await _restClient.ExecuteAsync(request);
        var content = response.Content!;
        return JsonConvert.DeserializeObject<GameResponseModel>(content)!;
    }

    public async Task<GameMovesResponseModel> PlayGame(GameMovesRequestModel requestModel)
    {
        RestRequest request = new RestRequest($"{endpoint}/GameMoves", Method.Post);
        request.AddJsonBody(requestModel);
        RestResponse response = await _restClient.ExecuteAsync(request);
        var content = response.Content!;
        return JsonConvert.DeserializeObject<GameMovesResponseModel>(content)!;
    }
}
