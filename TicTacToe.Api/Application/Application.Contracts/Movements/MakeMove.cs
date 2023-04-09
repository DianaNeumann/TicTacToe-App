using Application.Dto;
using MediatR;

namespace Application.Contracts.Movements;

public class MakeMove
{
    public record struct Command(Guid GameId, Guid PlayerId, int Position) : IRequest<Response>;

    public record struct Response(GameStateDto GameState);
}