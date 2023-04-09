using Application.Dto;
using MediatR;

namespace Application.Contracts.Movements;

public class MakeMove
{
    public record struct Command(int GameId, int PlayerId, int Position) : IRequest<Response>;

    public record struct Response(GameStateDto GameState);
}