using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Games;
using Domain.Movements;
using MediatR;
using static Application.Contracts.Movements.MakeMove;

namespace Application.Movements;

public class MakeMoveHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public MakeMoveHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.GetEntityAsync(request.GameId, cancellationToken);
        var player = await _context.Players.GetEntityAsync(request.PlayerId, cancellationToken);
        var position = request.Position;
        var movement = new Movement(game, player, position);
        var currentState = game.FillTheBoard(movement);
            
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(currentState.AsDto());
    }
}