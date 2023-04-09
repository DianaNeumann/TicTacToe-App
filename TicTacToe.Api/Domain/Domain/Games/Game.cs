using System.Text.Json.Serialization;
using Domain.Boards;
using Domain.Games.GameStates;
using Domain.Games.Tools;
using Domain.Movements;
using Domain.Players;

namespace Domain.Games;

public class Game
{
    public Game()
    {
        PlayerOne = null;
        PlayerTwo = null;
        Board = new Board();
        Movements = new HashSet<Movement>();
        Statistics = new HashSet<GameStats>();
    }

    public int Id { get; protected set; }

    public virtual Board Board { get; set; }
    public virtual Player? PlayerOne { get; private set; }
    public virtual Player? PlayerTwo { get; private set; }

    [JsonIgnore] public virtual ICollection<Movement> Movements { get; set; }
    [JsonIgnore] public virtual ICollection<GameStats> Statistics { get; set; }


    public GameState FillTheBoard(Movement movement)
    {
        var currentStatus = Board.FillTheBoardAndGetStatus(movement.Position, movement.Player.MovementValue);
        var currentField = Board.Field;

        if (Movements.Count != 0)
        {
            var timeDifference = movement.Time - Movements.Last().Time;
            if (timeDifference > TimeSpan.FromSeconds(15))
            {
                EndGameResolver.TimeIsOver(this);
            }
        }

        if (currentStatus != GameStatus.InProcess)
        {
            EndGameResolver.ComputeWin(this, currentStatus);
        }
        
        AddMoveToHistory(movement);
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

    public void AddMoveToHistory(Movement movement)
    {
        ArgumentNullException.ThrowIfNull(movement);
        Movements.Add(movement);
    }
}