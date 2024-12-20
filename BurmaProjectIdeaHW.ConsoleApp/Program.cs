using BurmaProjectIdeaHW.ConsoleApp;

Console.OutputEncoding = System.Text.Encoding.UTF8;

BaganMapHttpClientService httpClientService = new BaganMapHttpClientService();
//var content = await httpClientService.GetMaps();
//var content = await httpClientService.GetRoute("7C1DDEED-1B9E-4B54-8AE9-986BB44C42C1");
//Console.WriteLine(content.TravelRouteId);
//Console.WriteLine(content.TravelRouteName);
//Console.WriteLine(content.TravelRouteDescription);
//Console.WriteLine(content.PagodaList);
//var content = await httpClientService.GetBagodaDetail("1ba87a6f-0dd4-431b-ac71-82a235bf794b");
//Console.WriteLine(content.Id);
//Console.WriteLine(content.Description);

BaganMapRestClientService restService = new BaganMapRestClientService();
//var content = await restService.GetBaganMap();
//foreach (var map in content)
//{
//    Console.WriteLine("{0,-30} {1,-30}", map.Id, map.RouteName);
//}

//var content = await restService.GetRoute("7C1DDEED-1B9E-4B54-8AE9-986BB44C42C1");
//Console.WriteLine(content.TravelRouteId);
//Console.WriteLine(content.TravelRouteName);
//foreach (var item in content.PagodaList)
//{
//    Console.WriteLine("{");
//    Console.WriteLine(item.Id);
//    Console.WriteLine(item.PagodaMmName);
//    Console.WriteLine(item.PagodaEngName);
//    Console.WriteLine(item.Latitude);
//    Console.WriteLine(item.Longitude);
//    Console.WriteLine("}");
//}

//var content = await restService.GetBagodaDetail("1ba87a6f-0dd4-431b-ac71-82a235bf794b");
//Console.WriteLine(content.Id);
//Console.WriteLine(content.Description);

BaganMapRefitClientService refitService =  new BaganMapRefitClientService();
var content = await refitService.GetBaganMap();
foreach(var item in content)
{
    Console.WriteLine(item.Id);
    Console.WriteLine(item.RouteName);
}