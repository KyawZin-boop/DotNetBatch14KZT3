using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurmaProjectIdeaHW.ConsoleApp;

public class BaganMapModel
{
    public string? Id { get; set; }
    public string? RouteName { get; set; }
}

public class BaganMapResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public BaganMapModel Data { get; set; }
}

public class PagodaModel
{
    public string? Id { get; set; }
    public string? PagodaMmName { get; set; }
    public string? PagodaEngName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

public class TravelRouteModel
{
    public string? TravelRouteId { get; set; }
    public string? TravelRouteName { get; set; }
    public string? TravelRouteDescription { get; set; }
    public List<PagodaModel>? PagodaList { get; set; }
}

public class BagodaDetail
{
    public string? Id { get; set; }
    public string? Description { get; set; }
}