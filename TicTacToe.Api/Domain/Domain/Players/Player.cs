namespace Domain.Players;

public class Player
{
    protected Player()
    {
    }
    
    public Player(string name, string passwordHash)
    {
        Name = name;
        PasswordHash = passwordHash;
        EarnedPoints = 0;
    }

    public int Id { get; protected set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    public char MovementValue { get; set; }
    
    public double EarnedPoints { get; set; }
    
    public bool IsPlaying { get; set; }
}