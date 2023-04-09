using Application.Dto;
using MediatR;

namespace Application.Contracts.Game;

public class GetGameById
{
    public record Query(int GameId) : IRequest<Response>;
    public record Response(GameDto Game);
}