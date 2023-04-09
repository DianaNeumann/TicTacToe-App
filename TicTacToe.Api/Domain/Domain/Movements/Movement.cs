using Domain.Games;
using Domain.Players;

namespace Domain.Movements;

public class Movement
{
    public Movement()
    {
    }


    public Movement(Game game, Player player, int position)
    {
        Game = game;
        Player = player;
        Position = position;
        Time = DateTime.Now;
    }

    public int Id { get; set; }
    
    public virtual Game Game { get; set; }
    
    public virtual Player Player { get; set; }
    
    public int Position { get; set; }
    
    public DateTime Time { get; set; }
    
}