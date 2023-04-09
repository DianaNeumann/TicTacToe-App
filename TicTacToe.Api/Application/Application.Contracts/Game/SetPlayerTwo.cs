using Application.Dto;
using MediatR;

namespace Application.Contracts.Game;

public class SetPlayerTwo
{
    public record struct Command(Guid GameId, Guid PlayerId) : IRequest<Response>;
    public record struct Response(GameDto Game);
}