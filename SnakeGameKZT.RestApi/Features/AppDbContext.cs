using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SnakeGameKZT.RestApi.Features.Game;
using SnakeGameKZT.RestApi.Features.GameBoard;
using SnakeGameKZT.RestApi.Features.GameMoves;
using SnakeGameKZT.RestApi.Features.Player;

namespace SnakeGameKZT.RestApi.Features;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _connectionString = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "SnakeAndLadder_db",
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
    public DbSet<GameBoardModel> GameBoard { get; set; }
}
