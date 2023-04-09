using System.Text;
using Domain.Boards.Tools;
using Domain.Games.GameStates;
using Domain.Movements;

namespace Domain.Boards;

public class Board
{
    private const char DefaultSymbol = '-';
    
    public Guid Id { get; init; }
    public string Field { get; private set; }
    public Board()
    {
        Field = new string('-', 9);
    }
    
    public GameStatus FillTheBoardAndGetStatus(int position, char value)
    {
        ReplaceField(position, value);
        
        if (BoardStateChecker.CheckWin(Field.ToCharArray()))
        {
            return GetGameStatusFromChar(value);
        }

        if (BoardStateChecker.IsFull(Field.ToCharArray()))
        {
            return GameStatus.Draw;
        }

        return GameStatus.InProcess;

    }

    private void ReplaceField(int position, char value)
    {
        var stringBuilder = new StringBuilder(Field)
        {
            [position] = value
        };
 
        Field = stringBuilder.ToString();
    }

    private static GameStatus GetGameStatusFromChar(char value)
    {
        return value == (char)MovementValues.X ? GameStatus.PlayerOneWon : GameStatus.PlayerTwoWon;
    }
}