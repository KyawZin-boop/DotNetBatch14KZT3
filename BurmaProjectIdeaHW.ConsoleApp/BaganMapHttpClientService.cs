using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BurmaProjectIdeaHW.ConsoleApp;

public class BaganMapHttpClientService
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/bagan-map";
    private readonly HttpClient _httpClient;

    public BaganMapHttpClientService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<BaganMapModel>> GetMaps()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<List<BaganMapModel>>(content)!;
    }

    public async Task<TravelRouteModel> GetRoute(string id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TravelRouteModel>(content)!;
    }

    public async Task<PagodaDetail> GetBagodaDetail(string id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/detail/{id}");
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PagodaDetail>(content)!;
    }
}
