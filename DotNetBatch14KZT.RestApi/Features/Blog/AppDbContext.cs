using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KZT.RestApi.Features.Blog;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _connectionBuilder;

    public AppDbContext()
    {

        _connectionBuilder = new SqlConnectionStringBuilder()
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
            optionsBuilder.UseSqlServer(_connectionBuilder.ConnectionString);
        }
    }
    public DbSet<BlogModel> Blogs { get; set; }

}
