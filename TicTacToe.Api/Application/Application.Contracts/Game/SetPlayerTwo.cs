using Application.Dto;
using MediatR;

namespace Application.Contracts.Game;

public class SetPlayerTwo
{
    public record struct Command(int GameId, int PlayerId) : IRequest<Response>;
    public record struct Response(GameDto Game);
}