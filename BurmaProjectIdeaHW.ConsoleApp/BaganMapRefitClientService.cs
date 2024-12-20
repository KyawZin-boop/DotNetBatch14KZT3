using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace BurmaProjectIdeaHW.ConsoleApp;

public class BaganMapRefitClientService
{
    private readonly string domain = "https://burma-project-ideas.vercel.app";
    private readonly IBaganMapApi _api;

    public BaganMapRefitClientService()
    {
        _api = RestService.For<IBaganMapApi>(domain);
    }

    public async Task<List<BaganMapModel>> GetBaganMap()
    {
        var model = await _api.GetBaganMap();
        return model;
    }

    public async Task<TravelRouteModel> GetTravelRoute(string id)
    {
        var model = await _api.GetTravelRoute(id);
        return model;
    }

    public async Task<PagodaDetail> GetBagodaDetail(string id)
    {
        var model = await _api.GetBagodaDetail(id);
        return model;
    }
}

public interface IBaganMapApi
{
    [Get("/bagan-map")]
    Task<List<BaganMapModel>> GetBaganMap();

    [Get("/bagan-map/{id}")]
    Task<TravelRouteModel> GetTravelRoute(string id);

    [Get("/bagan-map/detail/{id}")]
    Task<PagodaDetail> GetBagodaDetail(string id);
}
