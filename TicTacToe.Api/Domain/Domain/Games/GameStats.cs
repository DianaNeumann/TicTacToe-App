using Domain.Boards;
using Domain.Players;

namespace Domain.Games;

public class GameStats
{
    public GameStats()
    {
    }

    public GameStats(Game game, Board board, Player? winner)
    {
        Game = game;
        Board = board;
        Winner = winner;
    }

    public int Id { get; set; }
    
    public virtual Game Game { get; set; }
    
    public virtual Board Board { get; set; }
    
    public virtual Player? Winner { get; set; }
}