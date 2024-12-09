using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KZT3.Shared;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _connectionStringBuilder;

    public AppDbContext()
    {
        _connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "test_db",
            UserID = "sa",
            Password = "Kyawzin@123",
            TrustServerCertificate = true,
        };
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionStringBuilder.ConnectionString);
        }
    }
    public DbSet<BlogModel> Blogs { get; set; }
}
