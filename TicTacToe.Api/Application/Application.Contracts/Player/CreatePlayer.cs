using Application.Dto;
using MediatR;

namespace Application.Contracts.Player;

public class CreatePlayer
{
    public record struct Command(string Name, string Password) : IRequest<Response>;

    public record struct Response(PlayerDto Player);
}