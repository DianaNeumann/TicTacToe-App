using Application.Abstractions.DataAccess;
using Domain.Boards;
using Domain.Games;
using Domain.Movements;
using Domain.Players;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

internal class DatabaseContext : DbContext, IDatabaseContext
{
    private IDatabaseContext _databaseContextImplementation;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Game> Games { get; private init; } = null!;
    
    public DbSet<Board> Boards { get; private init; } = null!;
    
    public DbSet<Movement> Movements { get; private init; } = null!;
    
    public DbSet<Player> Players { get; private init; } = null!;
   
    public DbSet<GameStats> gameStats { get; private init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}