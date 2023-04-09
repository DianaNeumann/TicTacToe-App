using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Game.GetGameById;

namespace Application.Game;

public class GetGameByIdHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetGameByIdHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.GetEntityAsync(request.GameId, cancellationToken);
        return new Response(game.AsDto());
    }
}