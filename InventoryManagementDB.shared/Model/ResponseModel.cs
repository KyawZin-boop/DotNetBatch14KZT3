using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDB.Shared.Model
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public object? Data { get; set; }
    }
}
