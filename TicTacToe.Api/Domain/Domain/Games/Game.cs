using Domain.Boards;
using Domain.Games.GameStates;
using Domain.Players;

namespace Domain.Games;

public class Game
{
    protected Game()
    {
    }

    public Game(Guid id)
    {
        Id = id;
        PlayerOne = null;
        PlayerTwo = null;
        Board = new Board();
    }
    public Game(Guid id, Player playerOne, Player playerTwo)
    {
        Id = id;
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
        
        PlayerOne.IsPlaying = true;
        PlayerTwo.IsPlaying = true;
        
        Board = new Board();
    }

    public Guid Id { get; protected set; }
    
    public virtual Board Board { get; set; }
    public virtual Player? PlayerOne { get; private set; }
    public virtual Player? PlayerTwo { get; private set; }

    public GameState FillTheBoard(int position, char value)
    {
        var currentStatus = Board.FillTheBoardAndGetStatus(position, value);
        var currentField = Board.Field;
        return new GameState(currentStatus, currentField);
    }

    public void SetPlayerOne(Player player)
    {
        if (PlayerOne != null) 
            PlayerOne.IsPlaying = false;

        PlayerOne = player;
        PlayerOne.IsPlaying = true;
    }
    
    public void SetPlayerTwo(Player player)
    {
        if (PlayerTwo != null) 
            PlayerTwo.IsPlaying = false;

        PlayerTwo = player;
        PlayerTwo.IsPlaying = true;
    }
}