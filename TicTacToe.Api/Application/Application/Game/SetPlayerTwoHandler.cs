using Application.Abstractions.DataAccess;
using Application.Contracts.Game;
using Application.Extensions;
using Application.Mapping;
using Domain.Movements;
using MediatR;

namespace Application.Game;

public class SetPlayerTwoHandler: IRequestHandler<SetPlayerTwo.Command, SetPlayerTwo.Response>
{
    private readonly IDatabaseContext _context;

    public SetPlayerTwoHandler(IDatabaseContext context)
    {
        _context = context;
    }


    public async Task<SetPlayerTwo.Response> Handle(SetPlayerTwo.Command request, CancellationToken cancellationToken)
    {
        var game = await _context.Games.GetEntityAsync(request.GameId, cancellationToken);
        var player = await _context.Players.GetEntityAsync(request.PlayerId, cancellationToken);
        
        player.MovementValue = (char)MovementValues.X;
        game.SetPlayerOne(player);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new SetPlayerTwo.Response(game.AsDto());
    }
}