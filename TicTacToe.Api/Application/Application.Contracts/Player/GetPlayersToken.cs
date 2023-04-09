using MediatR;

namespace Application.Contracts.Player;

public class GetPlayersToken
{
    public record struct Command(string Name, string Password) : IRequest<Response>;

    public record struct Response(string Token);
}