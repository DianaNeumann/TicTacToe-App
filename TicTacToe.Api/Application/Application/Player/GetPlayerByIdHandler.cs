using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Player.GetPlayerById;

namespace Application.Player;

public class GetPlayerByIdHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetPlayerByIdHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var player = await _context.Players.GetEntityAsync(request.PlayerId, cancellationToken);
        return new Response(player.AsDto());
    }
}