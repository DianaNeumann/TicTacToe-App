using Application.Abstractions.DataAccess;
using Application.Contracts.Game;
using Application.Extensions;
using Application.Mapping;
using Domain.Movements;
using MediatR;

namespace Application.Game;

public class SetPlayerOneHandler: IRequestHandler<SetPlayerOne.Command, SetPlayerOne.Response>
{
    private readonly IDatabaseContext _context;

    public SetPlayerOneHandler(IDatabaseContext context)
    {
        _context = context;
    }


    public async Task<SetPlayerOne.Response> Handle(SetPlayerOne.Command request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.GetEntityAsync(request.GameId, cancellationToken);
        var player = await _context.Players.GetEntityAsync(request.PlayerId, cancellationToken);
        
        player.MovementValue = (char)MovementValues.X;
        game.SetPlayerOne(player);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new SetPlayerOne.Response(game.AsDto());
    }
}