using InventoryDB.Shared.Model;
using InventoryManagementCaller.Console;

RefitService service = new RefitService();
var model = await service.GetProducts();
foreach (Product item in model)
{
    Console.WriteLine(item.ProductID);
    Console.WriteLine(item.ProductName);
    Console.WriteLine(item.Quantity);
    Console.WriteLine(item.Price);
    Console.WriteLine("");
}

Console.ReadLine();