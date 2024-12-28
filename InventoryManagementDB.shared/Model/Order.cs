using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDB.shared.Model;

public class Order
{
    public Guid OrderID { get; set; } = Guid.NewGuid();
    public List<Product> Items { get; set; } = new List<Product>();
    public decimal TotalPrice { get; set; }
}
