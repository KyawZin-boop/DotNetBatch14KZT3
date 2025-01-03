using InventoryDB.Shared.Model;
using InventoryManagementCaller.Console;
using InventoryManagementDB.Shared.Model;

ProductRefit productService = new ProductRefit();
InventoryRefit inventoryService = new InventoryRefit();
OrderRefit orderService = new OrderRefit();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine();
    Console.WriteLine("Pls Type the Number to Execute...");
    Console.WriteLine("1. Product Menu");
    Console.WriteLine("2. Order Menu");
    Console.WriteLine("3. Inventory Menu");
    Console.WriteLine("4. End Program");
    var menu = Console.ReadLine();
    Console.WriteLine();

    switch (menu)
    {
        case "1":
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("PODUCT MENU");
                Console.WriteLine("Pls Type the Number to Execute...");
                Console.WriteLine("1. Product Inventory");
                Console.WriteLine("2. Edit Product");
                Console.WriteLine("3. Add New Product");
                Console.WriteLine("4. Exit to Menu");
                var saleMenu = Console.ReadLine();
                Console.WriteLine();

                switch (saleMenu)
                {
                    case "1":
                        ShowProduct();
                        break;

                    case "2":
                        EditProduct();
                        break;

                    case "3":
                        AddProduct();
                        break;

                    case "4":
                        break;
                }
                if (saleMenu == "4") break;
            }
            break;

        case "2":
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Order Menu");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Add Item to Order");
                Console.WriteLine("3. Remove Item from Order");
                Console.WriteLine("4. Exit to Menu");
                var cashierMenu = Console.ReadLine();
                Console.WriteLine();

                switch (cashierMenu)
                {
                    case "1":
                        CreateOrder();
                        break;

                    case "2":
                        AddItemToOrder();
                        break;

                    case "3":
                        RemoveItemFromOrder();
                        break;

                    case "4":
                        break;
                }
                if (cashierMenu == "4") break;
            }
            break;

        case "3":
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Inventory Menu");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Add to Inventory");
                Console.WriteLine("3. Update Inventory Item");
                Console.WriteLine("4. Remove Inventory Item");
                Console.WriteLine("5. Exit to Menu");
                var managerMenu = Console.ReadLine();
                Console.WriteLine();

                switch (managerMenu)
                {
                    case "1":
                        GetInventory();
                        break;

                    case "2":
                        AddToInventory();
                        break;

                    case "3":
                        UpdateInventory();
                        break;

                    case "4":
                        RemoveFromInventory();
                        break;

                    case "5":
                        break;
                }
                if (managerMenu == "5") break;
            }
            break;

        case "4":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid Input");
            break;

    }
}


async void ShowProduct()
{

    var model = await productService.GetProducts();
    Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10:C}", "ID", "Name", "Stock", "Price");
    Console.WriteLine(new string('-', 50));

    Console.ForegroundColor = ConsoleColor.Green;
    foreach (var product in model)
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10} {4,-10:C}", product.ProductID!, product.ProductName, product.Quantity, product.Price);
    }
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine();
}

async void EditProduct()
{
    while (true)
    {
        ShowProduct();
        Console.WriteLine("Please Enter the Product ID you want to Edit");
        if (!Guid.TryParse(Console.ReadLine(), out Guid editId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        var item = await productService.GetProduct(editId);
        if (item is null)
        {
            Console.WriteLine("There's no Product with this ID");
            break;
        }

        Console.Write("Enter new Name ");
        string editName = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(editName)) item.ProductName = editName;

        Console.Write("Enter new Stock ");
        string editStock = Console.ReadLine()!;
        if (!int.TryParse(editStock, out int stock))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        item!.Quantity = Convert.ToInt32(editStock);

        Console.Write("Enter new Price ");
        string editPrice = Console.ReadLine()!;
        if (!Decimal.TryParse(editPrice, out decimal price))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        item!.Price = Convert.ToDecimal(editPrice);

        var editProduct = new InventoryDB.Shared.Model.ProductDTO
        {
            ProductName = item.ProductName,
            Quantity = item.Quantity,
            Price = item.Price
        };
        var response = await productService.UpdateProduct(editId, editProduct);
        Console.WriteLine(response.Message);
    }
}

async void AddProduct()
{
    while (true)
    {
        Console.WriteLine("Add New Product");
        Console.Write("Enter the Product Name = ");
        var newName = Console.ReadLine()!;
        if (string.IsNullOrEmpty(newName)) break;

        Console.Write("Enter the Product Stock = ");
        var newStock = Console.ReadLine();
        if (string.IsNullOrEmpty(newStock)) break;

        Console.Write("Enter the Product Price = ");
        var newPrice = Console.ReadLine();
        if (string.IsNullOrEmpty(newPrice)) break;

        var newProduct = new InventoryDB.Shared.Model.ProductDTO
        {
            ProductName = newName,
            Quantity = Convert.ToInt32(newStock),
            Price = Convert.ToDecimal(newPrice),
        };
        var response = await productService.AddProduct(newProduct);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(response.Message);
        Console.WriteLine();
        break;
    }
}

async void AddToInventory()
{
    while (true)
    {
        ShowProduct();
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        Console.WriteLine("Please Enter the product name");
        var name = Console.ReadLine();

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        Console.WriteLine("Please Enter the product price");
        if (!decimal.TryParse(Console.ReadLine(), out decimal itemPrice))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        var product = new InventoryDB.Shared.Model.Product
        {
            ProductID = itemId,
            ProductName = name,
            Quantity = quantity,
            Price = 0
        };
        var response = await inventoryService.AddToInventory(product);
        Console.WriteLine(response.Message);
        break;
    }
}

async void RemoveFromInventory()
{
    while (true)
    {
        ShowProduct();
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        var response = await inventoryService.RemoveFromInventory(itemId);
        Console.WriteLine(response.Message);
        break;
    }
}

async void GetInventory()
{
    var model = await inventoryService.GetInventory();
    Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10:C}", "ID", "Name", "Stock", "Price");
    Console.WriteLine(new string('-', 50));
    Console.ForegroundColor = ConsoleColor.Green;
    foreach (var product in model)
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10} {4,-10:C}", product.Item.ProductID!, product.Item.ProductName, product.Item.Quantity, product.Item.Price);
    }
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine();
}

async void UpdateInventory()
{
    while (true)
    {
        ShowProduct();
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        Console.WriteLine("Please Enter the product name");
        var name = Console.ReadLine();
        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        Console.WriteLine("Please Enter the product price");
        if (!decimal.TryParse(Console.ReadLine(), out decimal itemPrice))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        var product = new InventoryDB.Shared.Model.ProductDTO
        {
            ProductName = name,
            Quantity = quantity,
            Price = 0
        };
        var response = await inventoryService.UpdateInventoryItem(itemId, product);
        Console.WriteLine(response.Message);
        break;
    }
}

async void CreateOrder()
{
    while (true)
    {
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        Console.WriteLine("Please Enter the product price");
        if (!decimal.TryParse(Console.ReadLine(), out decimal itemPrice))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        var product = new InventoryDB.Shared.Model.Product
        {
            ProductID = itemId,
            Quantity = quantity,
            Price = itemPrice
        };
        var response = await orderService.CreateOrder(product);
        Console.WriteLine(response.Message);
        break;
    }
}

async void AddItemToOrder()
{
    while(true)
    {
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        Console.WriteLine("Please Enter the product price");
        if (!decimal.TryParse(Console.ReadLine(), out decimal itemPrice))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        Console.WriteLine("Please Enter the product quantity");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        var product = new InventoryDB.Shared.Model.Product
        {
            ProductID = itemId,
            Quantity = quantity,
            Price = itemPrice
        };
        var response = await orderService.AddItemToOrder(product);
        Console.WriteLine(response.Message);
        break;
    }
}

async void RemoveItemFromOrder()
{
    while (true)
    {
        Console.WriteLine("Please Enter the order ID");
        if (!decimal.TryParse(Console.ReadLine(), out decimal orderID))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }
        Console.WriteLine("Please Enter the product ID");
        if (!Guid.TryParse(Console.ReadLine(), out Guid itemId))
        {
            Console.WriteLine("Invalid Input!");
            break;
        }

        var response = await orderService.RemoveItemFromOrder(orderID, itemId);
        Console.WriteLine(response.Message);
        break;
    }
}
