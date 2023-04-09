namespace Domain.Games.GameStates;

public class GameState
{
    public GameState(GameStatus status, string field)
    {
        Status = status;
        Field = field;
    }
    
    public GameStatus Status { get; init; }
    public string Field { get; init; }
}