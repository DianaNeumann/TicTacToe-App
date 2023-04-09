using Application.Dto;
namespace Application.Mapping;

public static class BoardMapping
{
    public static BoardDto AsDto(this Domain.Boards.Board board)
        => new BoardDto(board.Id, board.Field);
}