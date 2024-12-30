using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDB.Shared.Model;

[Table("Tbl_Order")]
public class Order
{
    [Key]
    public Guid OrderID { get; set; } = Guid.NewGuid();
    public List<Product> Items { get; set; } 
    public decimal TotalPrice { get; set; }
}
