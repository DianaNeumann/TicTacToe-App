using Domain.Boards;
using Domain.Games.GameStates;

namespace Domain.Games.Tools;

public static class EndGameResolver
{
    private const double WinValue = 2;
    private const double DrawValue = 1; 
    public static void ComputeWin(Game game, GameStatus currentStatus)
    {
        switch (currentStatus)
        {
            case GameStatus.Draw:
                game.PlayerOne.EarnedPoints += DrawValue;
                game.PlayerTwo.EarnedPoints += DrawValue;
                var currentStat = new GameStats(game, game.Board, null);
                game.Statistics.Add(currentStat);
                break;
            case GameStatus.PlayerOneWon:
                game.PlayerOne.EarnedPoints += WinValue;
                currentStat = new GameStats(game, game.Board, game.PlayerOne);
                game.Statistics.Add(currentStat);
                break;
            case GameStatus.PlayerTwoWon:
                game.PlayerTwo.EarnedPoints += WinValue;
                currentStat = new GameStats(game, game.Board, game.PlayerTwo);
                game.Statistics.Add(currentStat);
                break;
        }
        game.Board = new Board();
    }

    public static void TimeIsOver(Game game)
    {
        var winner = game.Movements.Last().Player;
        winner.EarnedPoints += WinValue;
        var currentStat = new GameStats(game, game.Board, winner);
        game.Statistics.Add(currentStat);
        game.Board = new Board();
    }
    
}