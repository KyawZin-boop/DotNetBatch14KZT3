using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDB.Shared.Model;

public class Inventory
{
    public Guid InventoryId { get; set; } = Guid.NewGuid();
    public Product Item { get; set; }
    //public string ProductName { get; set; }
    //public int Quantity { get; set; }
    //public decimal Price { get; set; }
}

public class InventoryDTO
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}

