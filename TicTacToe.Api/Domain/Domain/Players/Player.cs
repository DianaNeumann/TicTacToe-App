namespace Domain.Players;

public class Player
{
    protected Player()
    {
    }
    
    public Player(Guid id, string name, string passwordHash)
    {
        Id = id;
        Name = name;
        PasswordHash = passwordHash;
    }

    public  Guid Id { get; protected set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    public char MovementValue { get; set; }
    
    public bool IsPlaying { get; set; }
}