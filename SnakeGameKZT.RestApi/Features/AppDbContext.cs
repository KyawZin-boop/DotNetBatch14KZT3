using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SnakeGameKZT.RestApi.Features;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _connectionString = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "snake_game_db",
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true
    };

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString.ConnectionString);
        }
    }
    public DbSet<PlayerModel> Players { get; set; }
    public DbSet<GameModel> Games { get; set; }
    public DbSet<GameMovesModel> GameMoves { get; set; }
}
