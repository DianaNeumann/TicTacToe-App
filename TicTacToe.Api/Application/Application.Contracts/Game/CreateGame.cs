using Application.Dto;
using MediatR;

namespace Application.Contracts.Game;

public class CreateGame
{
    public record struct Command() : IRequest<Response>;

    public record struct Response(GameDto Game);
}   