using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BurmaProjectIdeaHW.ConsoleApp;

public class BaganMapRestClientService
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/bagan-map";
    private readonly RestClient _restClient = new RestClient();

    public async Task<List<BaganMapModel>> GetBaganMap()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        RestResponse response = await _restClient.ExecuteAsync(request);
        var content = response.Content!;
        return JsonConvert.DeserializeObject<List<BaganMapModel>>(content)!;
    }

    public async Task<TravelRouteModel> GetRoute(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
        RestResponse response = await _restClient.ExecuteAsync(request);
        var content = response.Content!;
        return JsonConvert.DeserializeObject<TravelRouteModel>(content)!;
    }
}
