using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDB.Shared.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InventoryDB.Shared.AppSettings
{
    public class AppDbContext : DbContext
    {
        private readonly SqlConnectionStringBuilder _connBuilder;

        public AppDbContext()
        {
            _connBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "MiniInventory",
                UserID = "sa",
                Password = "Kyawzin@123",
                TrustServerCertificate = true
            };
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connBuilder.ConnectionString);
            }
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
