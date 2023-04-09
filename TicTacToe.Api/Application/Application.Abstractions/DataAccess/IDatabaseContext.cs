using Domain.Boards;
using Domain.Games;
using Domain.Players;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseContext
{
    DbSet<Game> Games { get; }
    DbSet<Board> Boards { get; }
    DbSet<Player> Players { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}